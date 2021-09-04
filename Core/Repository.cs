using Core.Categories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core
{
    public class Repository : IRepository
    {
        static string WorkingDirectory => Directory.GetCurrentDirectory() + "/data/";
        static string CategoriesDirectory => WorkingDirectory + "categories/";
        static string AutoCategoriesFileName => CategoriesDirectory + "autoCategories.json";
        static string CompositeCategoriesFileName => CategoriesDirectory + "compositeCategories.json";
        static string RegexCategoriesFileName => CategoriesDirectory + "regexCategories.json";
        static string TransactionsFileName => WorkingDirectory + "transactions.json";

        static string UsbDirectory => WorkingDirectory + "ukrsibbank/";
        static string KredobankDirectory => WorkingDirectory + "kredobank/";
        static string PrivatebankDirectory => WorkingDirectory + "privatbank/";

        public void SaveAutoCategories(IReadOnlyCollection <Category> categories)
        {
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(AutoCategoriesFileName, json);
        }

        public void SaveUpdatedTransactions()
        {
            File.WriteAllText(TransactionsFileName, State.Instance.SaveTransactionsToJson());
        }

        public RegexCategory[] GetRegexCategories()
        {
            var regexCategoriesJson = ReadFile(RegexCategoriesFileName);
            return string.IsNullOrWhiteSpace(regexCategoriesJson)
                ? Array.Empty<RegexCategory>()
                : JsonConvert.DeserializeObject<RegexCategory[]>(regexCategoriesJson);
        }

        public AutoCategory[] GetAutoCategories()
        {
            var autoCategoriesJson = ReadFile(AutoCategoriesFileName);
            return string.IsNullOrWhiteSpace(autoCategoriesJson)
                ? Array.Empty<AutoCategory>()
                : JsonConvert.DeserializeObject<AutoCategory[]>(autoCategoriesJson);
        }

        public CompositeCategory[] GetCompositeCategories()
        {
            var compositeCategoriesJson = ReadFile(CompositeCategoriesFileName);
            return string.IsNullOrWhiteSpace(compositeCategoriesJson)
                ? Array.Empty<CompositeCategory>()
                : JsonConvert.DeserializeObject<CompositeCategory[]>(compositeCategoriesJson);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            var transactionsJson = ReadFile(TransactionsFileName);
            return string.IsNullOrWhiteSpace(transactionsJson)
                   ? new List<Transaction>()
                   : JsonConvert.DeserializeObject<ICollection<Transaction>>(transactionsJson);
        }

        public IEnumerable<(string, Stream)> GetUsbFiles() =>
            Directory.GetFiles(UsbDirectory, "*.*", SearchOption.AllDirectories)
                .Select(f => ("usb", (Stream)File.OpenRead(f)));

        public  IEnumerable<(string, Stream)> GetPbFiles() =>
            Directory.GetFiles(PrivatebankDirectory, "*.*", SearchOption.AllDirectories)
                .Select(f => ("pb", (Stream)File.OpenRead(f)));

        public IEnumerable<(string, Stream)> GetKbFiles() =>
            Directory.GetFiles(KredobankDirectory, "*.*", SearchOption.AllDirectories)
                .Select(f => ("kb", (Stream)File.OpenRead(f)));
                    

        private string ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, "[]");
            }
            return File.ReadAllText(fileName);
        }
    }
}
