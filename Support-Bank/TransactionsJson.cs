using NLog;
using NLog.Config;
using NLog.Targets;
using Newtonsoft.Json;
namespace SupportBank
{
    
    class TransactionsJson
    {
        private readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public TransactionJson CreateTransaction(DateTime date, string from, string to, string narrative, decimal amount)
        {

            TransactionJson transactionJson = new TransactionJson(date, from, to, narrative, amount);
            return transactionJson;
        }

        public List<TransactionJson> ReturnListOfTransactions(string User)
        {
            StreamReader reader = new StreamReader("Transactions2013.json"); 
            string jsonString = reader.ReadToEnd(); 
            List<TransactionJson>? transactionsJson = JsonConvert.DeserializeObject<List<TransactionJson>>(jsonString);
            List<TransactionJson> AllUserTransactions = new List<TransactionJson>();
            Console.WriteLine(transactionsJson[0].FromAccount);
            foreach (var item in transactionsJson)
            {
                if (item.FromAccount == User || item.ToAccount == User)
                    {
                        AllUserTransactions.Add(item);
                        Console.WriteLine(item.Amount);
                    }
            }
            return AllUserTransactions;
        }
        
    }
}