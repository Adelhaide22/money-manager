﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Core.Importers
{
    public class UkrSibTransactionsImporter : ITransactionsImporter
    {
        public IList<Transaction> Load(Stream file)
        {
            var saved = Thread.CurrentThread.CurrentCulture;
            var transactions = new List<Transaction>();

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using var reader = ExcelReaderFactory.CreateOpenXmlReader(file);
                var dataSet = reader.AsDataSet();
                var dataTable = dataSet.Tables[0];
                for (var i = 1; i < dataTable.Rows.Count; i++)
                {
                    var date = dataTable.Rows[i][1].ToString();
                    var category = dataTable.Rows[i][4].ToString();
                    var cardNumber = dataTable.Rows[i][3].ToString();
                    var description = dataTable.Rows[i][2].ToString().Trim();
                    var amount = dataTable.Rows[i][5].ToString();
                    var currency = dataTable.Rows[i][6].ToString();
                    transactions.Add(new Transaction(cardNumber, Date.Parse(date),
                        new Money(double.Parse(amount), MoneyManager.ParseCurrency(currency)), description, category));
                }
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = saved;
            }            

            return transactions;
        }
    }
}
