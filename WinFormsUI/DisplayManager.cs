using Core;
using Core.Categories;
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

        public static string AddPrefixToCategory(double todayRelative, Category c)
        {
            var level = todayRelative switch
            {
                _ when todayRelative <= 0 => Levels.Empty,
                _ when todayRelative <= 0.1 => Levels.Low,
                _ when todayRelative < 1 => Levels.Normal,
                _ => Levels.Full,
            };

            return level switch
            {
                _ when Equals(level, Levels.Empty) => "(EMPTY) ",
                _ when Equals(level, Levels.Normal) => "",
                _ when Equals(level, Levels.Low) => "(LOW) ",
                _ => "(FULL) ",
            } + c.Name;
        }
    }
}
