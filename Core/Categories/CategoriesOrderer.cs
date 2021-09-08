using System;
using System.Collections.Generic;

namespace Core.Categories
{
    public class CategoriesOrderer : IComparer<Category>
    {
        public static Dictionary<Type, int> TypeToInt { get; set; } =
            new Dictionary<Type, int>
            {
                { typeof(CompositeCategory), 1 },
                { typeof(RegexCategory), 2 },
                { typeof(AutoCategory), 3 },
            };

        public int Compare(Category? x, Category? y) => (x?.GetType(), y?.GetType()) switch
        {
            (null, null) => 0,
            (null, _) => -1,
            (_, null) => 1,
            (var a, var b) when a == b => x.Name.CompareTo(y.Name),
            (var a, var b) => TypeToInt[a].CompareTo(TypeToInt[b]),
        };
    }
}
