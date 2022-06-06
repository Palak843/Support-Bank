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
            using (var reader = new StreamReader("DodgyTransactions2015.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    if (values[1] == User || values[2] == User)
                    {
                        try
                        {
                            DateTime passDate = DateTime.Parse(values[0]);
                        }
                        catch (FormatException exception)
                        {
                            Console.WriteLine($"The transaction from {values[1]} to {values[2]} with the reference \"{values[3]}\" has invalid date.");
                            continue;
                        }
                        try
                        {
                            decimal passAmount = decimal.Parse(values[4]);
                        }
                        catch (FormatException exception)
                        {
                            Console.WriteLine($"The transaction from {values[1]} to {values[2]} on date {values[0]} has invalid amount.");
                            continue;
                        }
                        Transaction listElement = CreateTransaction(values[0], values[1], values[2], values[3], values[4]);
                        AllUserTransactions.Add(listElement);
                    }
                }
            }

            return AllUserTransactions;
        }
    }
}