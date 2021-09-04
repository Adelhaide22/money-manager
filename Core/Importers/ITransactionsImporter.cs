using System.Collections.Generic;
using System.IO;

namespace Core
{
    interface ITransactionsImporter
    {
        IList<Transaction> Load(Stream file);
    }
}
