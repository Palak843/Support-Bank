using NLog;
using NLog.Config;
using NLog.Targets;
using Newtonsoft.Json;
namespace SupportBank
{

    class TransactionsJson
    {
        private readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public List<TransactionJson> ReturnListOfTransactions(string User)
        {
            StreamReader reader = new StreamReader("Transactions2013.json");
            string jsonString = reader.ReadToEnd();
            List<TransactionJson> transactionsJson = JsonConvert.DeserializeObject<List<TransactionJson>>(jsonString);
            List<TransactionJson> AllUserTransactions = new List<TransactionJson>();
            foreach (var item in transactionsJson)
            {
                if (item.FromAccount == User || item.ToAccount == User)
                {
                    AllUserTransactions.Add(item);
                }
            }
            return AllUserTransactions;
        }

    }
}