using NLog;
using NLog.Config;
using NLog.Targets;
using System;

    namespace SupportBank {
        public class Program {
            private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
            public static void Main (String[] args)
            {
                var config = new LoggingConfiguration();
                var target = new FileTarget { FileName = @"C:\Training\Support-Bank\Support-Bank\Logging.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
                config.AddTarget("File Logger", target);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
                LogManager.Configuration = config;

                Console.WriteLine("Do you want to see a summary of everyones statements?");
                string? listAll = Console.ReadLine();
                if (listAll == "yes")
                {
                    TotalMoney allTransactions = new TotalMoney();
                    allTransactions.CreateUserTotalMoney();
                }

                string? username = "";
                Transactions transactions = new Transactions();
                while (username != null)
                {
                    try
                    {
                        Console.WriteLine("Whose transactions would you like to see?");
                        username = Console.ReadLine();
                        List<Transaction> userTransaction = transactions.ReturnListOfTransactions(username);
                        if (userTransaction.Count == 0)
                        {
                            throw new ArgumentNullException();
                        }
                       
                        foreach(var item in userTransaction)
                        {
                            Console.WriteLine($"Date : {item.Date}, From : {item.From}, To : {item.To}, Description : {item.Narrative}, Amount : {item.Amount}");
                        }
                    }
                    catch (ArgumentNullException exception)
                    {
                        Console.WriteLine("There is no person with this name.");
                        Logger.Error($"The user submitted name {username} which is not on file.");
                        continue;
                    }
                    break;
                }
            }
        }
    }