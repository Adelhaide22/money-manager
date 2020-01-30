﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public static class State
    {
        public static SortedSet<Transaction> Transactions { get; } = new SortedSet<Transaction>();
        public static HashSet<string> Categories { get; } = new HashSet<string>() { "all", "income", "expences" };
        public static event Action OnStateUpdated;
        private static Dictionary<string, Func<Transaction, bool>> categoryFilters { get; } = new Dictionary<string, Func<Transaction, bool>>();

        static State()
        {
            categoryFilters.Add("all", t => true);
            categoryFilters.Add("income", t => t.IsIncome);
            categoryFilters.Add("expences", t => t.IsExpence);
        }

        public static Task Init()
        {
            Transactions.UnionWith(StateManager.Load());
            OnStateUpdated?.Invoke();

            // TODO: Set up category filters with custom filters from config file

            var credentials = ConfigManager.GetCredentials();

            return Task.WhenAll(
                credentials.Select(c => PrivatTransactionsImporter.ImportTransactions(c, ts =>
                {
                    if (ts.All(Transactions.Contains))
                    {
                        return;
                    }
                    Transactions.UnionWith(ts);
                    StateManager.Save();
                    OnStateUpdated?.Invoke();
                })));
        }

        public static TimeSeries GetTimeSeries(string category, double smoothingRatio = 0) => GetTimeSeries(new[] { category }, smoothingRatio);

        public static TimeSeries GetTimeSeries(IEnumerable<string> categories, double smoothingRatio = 0)
        {
            Func<Transaction, bool> filter = t => categories.Any(c => categoryFilters[c](t));
            var filtered = Transactions.Where(filter);
            return new TimeSeries(filtered, smoothingRatio);
        }

        public static IEnumerable<Transaction> GetTransactions(string category) => GetTransactions(new[] { category });

        public static IEnumerable<Transaction> GetTransactions(IEnumerable<string> categories)
        {
            Func<Transaction, bool> filter = t => categories.Any(c => categoryFilters[c](t));
            return Transactions.Where(filter);
        }
    }
}
