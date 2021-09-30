using Core.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Helpers
{
    public static class CategoriesHelper
    {
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
    }
}
