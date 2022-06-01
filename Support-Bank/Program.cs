// See https://aka.ms/new-console-template for more information
using System;
    namespace SupportBank {
        public class Program {
            public static void Main (String[] args)
            {
                // TotalMoney totalMoney = new TotalMoney();
                // totalMoney.CreateUserTotalMoney();

                Transactions transactions = new Transactions();
                List<string[]> userTransaction = transactions.ReturnListOfTransactions("Jon A");
                foreach(var item in userTransaction)
                {
                    Console.WriteLine($"Date : {item[0]}, From : {item[1]}, To : {item[2]}, Description : {item[3]}, Amount : {item[4]}");
                }

            }
        }



    }