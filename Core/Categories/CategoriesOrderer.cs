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

        public int Compare(Category x, Category y)
        {
            var typeX = x.GetType();
            var typeY = y.GetType();

            if (typeX == typeY)
            {
                return x.Name.CompareTo(y.Name);
            }

            return TypeToInt[typeX].CompareTo(TypeToInt[typeY]);
        }
    }
}
