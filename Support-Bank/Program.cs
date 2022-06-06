using System;
    namespace SupportBank {
        public class Program {
            public static void Main (String[] args)
            {
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