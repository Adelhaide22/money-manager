using System;
using Newtonsoft.Json;

namespace Core
{
    public class Transaction : IComparable<Transaction>
    {
        [JsonConstructor]
        public Transaction(string cardNumber, Date date, Money amount, string description, string category, int? hash = null)
        {
            CardNumber = cardNumber;
            Date = date;
            Amount = amount;
            Description = description;
            Category = category;
            Hash = hash ?? GetInitialHashCode();
        }

        public string CardNumber { get; }
        public Date Date { get; }
        public Money Amount { get; }

        [JsonIgnore]
        public Money AbsoluteAmount => new Money(Math.Abs(Amount.Amount), Amount.Currency);

        public string Description { get; }
        public string Category { get; }

        private int Hash { get; }

        public int CompareTo(Transaction other) => Date.CompareTo(other.Date);

        public override int GetHashCode()
        {
            return Hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Transaction other && Date == other.Date && Hash == other.Hash;
        }

        private int GetInitialHashCode()
        {
            const int k = 17;
            var hash = Date.GetHashCode();
            hash = k * hash + Category.GetHashCode();
            hash = k * hash + Amount.GetHashCode();
            hash = k * hash + CardNumber.GetHashCode();
            hash = k * hash + Description.GetHashCode();
            return hash;
        }
    }
}
