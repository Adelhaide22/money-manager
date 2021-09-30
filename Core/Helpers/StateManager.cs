using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Categories;
using Core.Helpers;
using Core.Importers;

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

        public static void LoadCategories(RegexCategory[] regex, AutoCategory[] auto, CompositeCategory[] composite)
        {
            var categories = regex.Cast<Category>().Concat(auto).Concat(composite).Concat(State.Instance.Categories).ToHashSet();

            State.Instance = new State(categories, State.Instance.Transactions.ToHashSet());
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

        public static void UpdateStateWithNewCategory<T>(T category) where T: Category
        {
            State.Instance = new State(State.Instance.Categories.Concat(new[] { category }).ToHashSet(), State.Instance.Transactions.ToHashSet());
        }

        public static void DeleteCategory(Category category)
        {
            var categories = State.Instance.Categories.Where(c => !c.Equals(category)).ToHashSet();
            State.Instance = new State(categories, State.Instance.Transactions.ToHashSet());
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
    }
}
