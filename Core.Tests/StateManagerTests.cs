using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Core.Tests
{
    [TestFixture]
    public class StateManagerTests
    {
        const string transactionsFile = "\\..\\..\\..\\TestData\\transactions.json";

        [Test]
        [Order(0)]
        public void Import()
        {
            var transactionsJson = File.ReadAllText(Directory.GetCurrentDirectory() + transactionsFile);
            StateManager.LoadTransactions(Enumerable.Empty<(string, Stream)>(), JsonConvert.DeserializeObject<ICollection<Transaction>>(transactionsJson));
            State.Instance.Transactions.Should().HaveCount(2);
        }

        [Test]
        [Order(1)]
        public void Edit()
        {
            var rndCategory = Randomizer.CreateRandomizer().GetString(100);
            var t1 = State.Instance.Transactions.First();
            var tNew = new Transaction(t1.CardNumber, t1.Date, t1.Amount,
                t1.Description, rndCategory, t1.Hash);

            StateManager.UpdateTransaction(tNew);

            State.Instance.Transactions.Should().HaveCount(2);
            State.Instance.Transactions.Should().Contain(tNew);
            var updatedTransaction = State.Instance.Transactions.First(tNew.Equals);
            updatedTransaction.Category.Should().Be(rndCategory);
        }


        [Test]
        [Order(2)]
        public void Save()
        {
            var t1 = State.Instance.SaveTransactionsToJson();
            var oldState = State.Instance;
            StateManager.LoadTransactions(Enumerable.Empty<(string, Stream)>(), JsonConvert.DeserializeObject<ICollection<Transaction>>(t1));

            State.Instance.Transactions.Should().BeEquivalentTo(oldState.Transactions);
        }
    }
}
