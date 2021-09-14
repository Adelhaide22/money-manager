using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Categories;
using Core.Importers;
using Core.TimeSeries;
using Newtonsoft.Json;

namespace Core
{
    public static class StateManager
    {
        private static Dictionary<string, ITransactionsImporter> importers = new Dictionary<string, ITransactionsImporter>
        {
            ["pb"] = new PrivatTransactionsImporter(),
            ["usb"] = new UkrSibTransactionsImporter(),
            ["kb"] = new KredoTransactionsImporter(),
        };

        public static string SaveRegex()
        {
            return JsonConvert.SerializeObject(State.Instance.Categories.Where(c => c is RegexCategory), Formatting.Indented);
        }

        public static string SaveComposite()
        {
            return JsonConvert.SerializeObject(State.Instance.Categories.Where(c => c is CompositeCategory), Formatting.Indented);
        }

        public static void LoadCategories(RegexCategory[] regex, AutoCategory[] auto, CompositeCategory[] composite)
        {
            State.Instance = new State(regex.Cast<Category>().Concat(auto).Concat(composite).Concat(State.Instance.Categories).ToHashSet(), State.Instance.Transactions.ToHashSet());
        }

        public static void LoadTransactions(IEnumerable<(string key, Stream stream)> files, IEnumerable<Transaction> modifiedTransactions)
        {
            var newTransactions = new List<Transaction>();
            foreach (var (key, stream) in files)
            {
                newTransactions.AddRange(importers[key].Load(stream));
            }

            var transactions = new List<Transaction>();
            transactions.AddRange(modifiedTransactions);
            transactions.AddRange(newTransactions);
            transactions.AddRange(State.Instance.Transactions);

            State.Instance = new State(State.Instance.Categories.ToHashSet(), transactions.ToHashSet());

            Func<string, string> suggestName = s => $"[Auto] {s}";
            var newCategories = State.Instance.Transactions.Select(t => t.Category).Where(c => c is { } && State.Instance.Categories.All(sc => sc.Name != suggestName(c)))
                .Select(c => new AutoCategory(suggestName(c), 1, 10000, c)).ToList();

            var categories = new List<Category>(); 
            categories.AddRange(State.Instance.Categories);
            categories.AddRange(newCategories);

            State.Instance = new State(categories.ToHashSet(), State.Instance.Transactions.ToHashSet());

            var transactionsWithoutCategory = State.Instance.Transactions.Where(t => string.IsNullOrWhiteSpace(t.Category));

            foreach (var t in transactionsWithoutCategory)
            {
                var c = State.Instance.GetAllMatchingCategoriesOfType<CompositeCategory>(t).ToList();
                if (c.Count == 1)
                {
                    var newTransaction = new Transaction(t.CardNumber, t.Date, t.Amount, t.Description, c[0], t.GetHashCode());
                    UpdateTransaction(newTransaction);
                }
            }
        }

        public static void UpdateTransaction(Transaction transaction)
        {
            var transactions = State.Instance.Transactions.ToHashSet();
            if (!transactions.Contains(transaction))
            {
                throw new ArgumentException($"{nameof(transaction)} not found");
            }
            transactions.Remove(transaction);
            transactions.Add(transaction);
            State.Instance = new State(State.Instance.Categories.ToHashSet(), transactions);
        }

        public static void UpdateCategory(Category category)
        {
            var categories = State.Instance.Categories.ToHashSet();
            if (!categories.Contains(category))
            {
                throw new ArgumentException($"{nameof(category)} not found");
            }
            categories.Remove(category);
            categories.Add(category);
            State.Instance = new State(categories, State.Instance.Transactions.ToHashSet());
        }

        public static Func<Transaction, bool> GetFilterForCategory(string categoryName)
        {
            if (State.Instance.Categories.All(c => c.Name != categoryName))
            {
                return t => false;
            }
            var c = State.Instance.Categories.FirstOrDefault(c => c.Name == categoryName);
            switch (c)
            {
                case AutoCategory autoCategory:
                    return t => t.Category == autoCategory.Category;
                case RegexCategory regexCategory:
                    return t => regexCategory.Rules.Any(r => Regex.IsMatch(t.CardNumber, r.CardNumber)
                                                && Regex.IsMatch(t.Description, r.Description)
                                                && Regex.IsMatch(t.Category, r.Category)
                                                && r.Amount[1..] is var ruleAmount
                                                && r.Amount[0] switch
                                                {
                                                    '>' => t.Amount.Amount > int.Parse(ruleAmount),
                                                    '<' => t.Amount.Amount < int.Parse(ruleAmount),
                                                    '=' => t.Amount.Amount == int.Parse(ruleAmount),
                                                    '*' => true,
                                                    _ => throw new NotSupportedException()
                                                }
                                                );
                case CompositeCategory compositeCategory:                
                    var filters = compositeCategory.Categories.Select(GetFilterForCategory).ToArray();
                    return t => filters.Any(f => f(t));                
                case null:
                    return t => false;
                default:
                    throw new NotSupportedException($"Category type {c.GetType()} is not supported");
            }
        }

        public static IEnumerable<string> GetAllMatchingCategories(this State state, Transaction transaction)
        {
            return state.Categories
                .Where(c => GetFilterForCategory(c.Name)(transaction))
                .Select(c => c.Name)
                .ToList();
        }

        public static IEnumerable<string> GetAllMatchingCategoriesOfType<T>(this State state, Transaction transaction) where T : Category
        {
            return state.Categories
                .OfType<T>()
                .Where(c => GetFilterForCategory(c.Name)(transaction))
                .Select(c => c.Name)
                .ToList();
        }

        public static SmoothedTimeSeries GetSmoothedTimeSeries(string category, double smoothingRatio)
        {
            var filteredTransactions = State.Instance.Transactions.Where(GetFilterForCategory(category)).ToList();
            return new SmoothedTimeSeries(filteredTransactions, smoothingRatio);
        }

        public static CumulativeTimeSeries GetCumulativeTimeSeries(string category, double increment, double capacity)
        {
            var filteredTransactions = State.Instance.Transactions.Where(GetFilterForCategory(category)).ToList();
            return new CumulativeTimeSeries(filteredTransactions, increment, capacity);
        }

        public static SmoothedTimeSeries GetSmoothedTimeSeriesUnion(IEnumerable<string> categories, double smoothingRatio)
        {
            Func<Transaction, bool> filter = t => categories.Any(c => GetFilterForCategory(c)(t));
            var filteredTransactions = State.Instance.Transactions.Where(filter).ToList();
            return new SmoothedTimeSeries(filteredTransactions, smoothingRatio);
        }

        public static CumulativeTimeSeries GetCumulativeTimeSeriesUnion(IEnumerable<string> categories, double smoothingRatio)
        {
            return new CumulativeTimeSeries(1, 1);
        }

        public static IEnumerable<Transaction> GetTransactions(string category, Date start, Date end)
        {
            var filteredTransactions = State.Instance.Transactions
                                                   .Where(t => t.Date >= start && t.Date <= end)
                                                   .Where(GetFilterForCategory(category))
                                                   .OrderBy(t => t.Date)
                                                   .ToList();
            return filteredTransactions;
        }

        public static IEnumerable<Transaction> GetTransactionsUnion(IEnumerable<string> categories, Date start, Date end)
        {
            Func<Transaction, bool> filter = t => categories.Any(c => GetFilterForCategory(c)(t));
            return State.Instance.Transactions
                               .Where(t => t.Date >= start && t.Date <= end)
                               .Where(filter)
                               .OrderBy(t => t.Date)
                               .ToList();
        }

        public static string SaveTransactionsToJson(this State state)
        {
            return JsonConvert.SerializeObject(state.Transactions, Formatting.Indented);
        }
    }
}
