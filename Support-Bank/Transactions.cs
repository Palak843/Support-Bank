namespace SupportBank
{
    class Transactions
    {
        public Transaction CreateTransaction(string date, string from, string to, string narrative, string amount)
        {
            Transaction transaction = new Transaction(DateTime.Parse(date), from, to, narrative, decimal.Parse(amount));
            return transaction;
        }

        public List<Transaction> ReturnListOfTransactions(string User)
        {
            List<Transaction> AllUserTransactions = new List<Transaction>();
            using (var reader = new StreamReader("Transactions2014.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    if (values[1] == User || values[2] == User)
                    {
                        Transaction listElement = CreateTransaction(values[0], values[1], values[2], values[3], values[4]);
                        AllUserTransactions.Add(listElement);
                    }
                }
            }

            return AllUserTransactions;
        }
    }
}