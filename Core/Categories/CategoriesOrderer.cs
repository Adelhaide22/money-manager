using System;
using System.Collections.Generic;

namespace Core.Categories
{
    public class CategoriesOrderer : IComparer<Category>
    {
        public int Compare(Category x, Category y)
        {
            var typeX = x.GetType();
            var typeY = y.GetType();

            if (typeX == typeY)
            {
                return x.Name.CompareTo(y.Name);
            }

            var typeToInt = new Dictionary<Type, int>
            {
                { typeof(CompositeCategory), 1 },
                { typeof(RegexCategory), 2 },
                { typeof(AutoCategory), 3 },
            };

            return typeToInt[typeX].CompareTo(typeToInt[typeY]);
        }
    }
}
