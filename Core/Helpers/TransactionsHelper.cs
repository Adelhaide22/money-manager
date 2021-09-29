using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class TransactionsHelper
    {
        public static IEnumerable<Transaction> GetTransactionsUnion(IEnumerable<string> categories, Date start, Date end)
        {
            Func<Transaction, bool> filter = t => categories.Any(c => CategoriesHelper.GetFilterForCategory(c)(t));
            return State.Instance.Transactions
                               .Where(t => t.Date >= start && t.Date <= end)
                               .Where(filter)
                               .OrderBy(t => t.Date)
                               .ToList();
        }
    }
}
