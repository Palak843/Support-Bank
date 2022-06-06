using NLog;
using NLog.Config;
using NLog.Targets;
using System;

    namespace SupportBank {
        public class Program {
            public static void Main (String[] args)
            {
                var config = new LoggingConfiguration();
                var target = new FileTarget { FileName = @"C:\Training\Support-Bank\Support-Bank\Logging.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
                config.AddTarget("File Logger", target);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
                LogManager.Configuration = config;

                Transactions transactions = new Transactions();
                List<Transaction> userTransaction = transactions.ReturnListOfTransactions("Sarah T");
                foreach(var item in userTransaction)
                {
                    Console.WriteLine($"Date : {item.Date}, From : {item.From}, To : {item.To}, Description : {item.Narrative}, Amount : {item.Amount}");
                }

                TotalMoney allTransactions = new TotalMoney();
                allTransactions.CreateUserTotalMoney();
                
            }
        }
    }