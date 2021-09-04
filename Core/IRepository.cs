using Core.Categories;
using System.Collections.Generic;
using System.IO;

namespace Core
{
    public interface IRepository
    {
        void SaveAutoCategories(IReadOnlyCollection<Category> categories);

        void SaveUpdatedTransactions();

        RegexCategory[] GetRegexCategories();

        AutoCategory[] GetAutoCategories();

        CompositeCategory[] GetCompositeCategories();

        IEnumerable<Transaction> GetTransactions();

        IEnumerable<(string, Stream)> GetUsbFiles();
        IEnumerable<(string, Stream)> GetPbFiles();
        IEnumerable<(string, Stream)> GetKbFiles();
    }
}
