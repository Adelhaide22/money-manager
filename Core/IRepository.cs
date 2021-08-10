using Core.Categories;
using System.Collections.Generic;
using System.IO;

namespace Core
{
    public interface IRepository
    {
        public void SaveAutoCategoriesToFile();

        public void SaveUpdatedTransactions();

        public RegexCategory[] GetRegexCategories();

        public AutoCategory[] GetAutoCategories();

        public CompositeCategory[] GetCompositeCategories();

        public IEnumerable<Transaction> GetTransactions();

        public IEnumerable<(string, Stream)> GetUsbFiles();

        public IEnumerable<(string, Stream)> GetPbFiles();

        public IEnumerable<(string, Stream)> GetKbFiles();
    }
}
