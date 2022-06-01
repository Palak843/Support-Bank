namespace SupportBank
{
    class Transactions
    {

        public string[]CreateTransactions(string date, string from, string to, string narrative, string amount)
        {
            string[] transaction = {date, from, to, narrative, amount};
            return transaction;
        }

        public List<string[]> ReturnListOfTransactions(string User)
        {
            List<string[]> AllUserTransactions = new List<string[]>();
            using (var reader = new StreamReader("Transactions2014.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    if (values[1] == User || values[2] == User)
                    {
                        string[] listElement = CreateTransactions(values[0], values[1], values[2], values[3], values[4]);
                        AllUserTransactions.Add(listElement);
                    }
                }
            }
            return AllUserTransactions;
        }
    }
}