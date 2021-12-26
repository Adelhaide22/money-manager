using Core.TimeSeries;
using System.Linq;

namespace Core.Helpers
{
    public static class TimeSeriesHelper
    {       
        public static SmoothedTimeSeries GetSmoothedTimeSeries(string category, double smoothingRatio)
        {
            var filteredTransactions = State.Instance.Transactions.Where(CategoriesHelper.GetFilterForCategory(category)).ToList();
            return new SmoothedTimeSeries(filteredTransactions, smoothingRatio);
        }

        public static CumulativeTimeSeries GetCumulativeTimeSeries(string category, double increment, double capacity)
        {
            var filteredTransactions = State.Instance.Transactions.Where(CategoriesHelper.GetFilterForCategory(category)).ToList();
            return new CumulativeTimeSeries(filteredTransactions, increment, capacity);
        }
    }
}
