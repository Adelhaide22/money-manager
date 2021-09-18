using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static string DisplayList(IReadOnlyCollection<string> text)
        {
            return string.Join(Environment.NewLine, text);
        }

        internal static string DisplayRules(IReadOnlyCollection<Rule> rules)
        {
            var sb = new StringBuilder();
            var index = 1;
            foreach (var r in rules)
            {
                sb.AppendLine($"Rule #{index}");
                sb.AppendLine();
                sb.AppendLine($"Amount: {r.Amount}");
                sb.AppendLine($"CardNumber: {r.CardNumber}");
                sb.AppendLine($"Category: {r.Category}");
                sb.AppendLine($"Description: {r.Description}");
                index++;
                sb.AppendLine();
            }
            return sb.ToString();
        }

        internal static IReadOnlyCollection<Rule> ReadRules(string text)
        {
            var strings = text.Split("\r\n").Where(s => !string.IsNullOrEmpty(s)).Where(c => !c.StartsWith("Rule")).ToList();
            var rules = new List<Rule>();
            while (strings.Count > 0)
            {
                var amount = strings[0].Replace("Amount: ", string.Empty);
                var cardNumber = strings[1].Replace("CardNumber: ", string.Empty);
                var category = strings[2].Replace("Category: ", string.Empty);
                var description = strings[3].Replace("Description: ", string.Empty);

                strings.RemoveRange(0, 4);

                rules.Add(new Rule(cardNumber, amount, description, category));
            }

            return rules;
        }
    }
}
