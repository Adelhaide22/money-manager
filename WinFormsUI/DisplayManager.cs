using Core;
using System;
using System.Collections.Generic;

namespace WinFormsUI
{
    public static class DisplayManager
    {
        public static string FormatLedgerRecord(Transaction transaction, IEnumerable<string> categories)
        {
            return $"{transaction.Date.ToString("yyyy.MM.dd")}:" + $"{transaction.Amount.Amount}".PadLeft(10) 
                + $" {transaction.Amount.Currency} [{string.Join(", ", categories)}] {transaction.Description}";
        }

        public static string GetPrefix(Levels level)
        {
            return level switch
            {
                Levels.Empty => "(EMPTY) ",
                Levels.Normal => "",
                Levels.Low => "(LOW) ",
                _ => "(FULL) ",
            };
        }

        public static IReadOnlyCollection<string> ReadList(string text)
        {
            return text.Split("\r\n");
        }

        public static string DisplayList(IReadOnlyCollection<string> categories)
        {
            return string.Join(Environment.NewLine, categories);
        }
    }
}
