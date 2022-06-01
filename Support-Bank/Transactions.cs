namespace SupportBank
{
    class Transactions
    {
        public Dictionary <string,decimal> UserTotalMoney {get; set;} = new Dictionary<string, decimal>();
        
        public Dictionary <string,decimal> CreateUserTotalMoney()
        {
            using (var reader = new StreamReader("Transactions2014.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    if (!UserTotalMoney.ContainsKey(values[1]))
                    {
                        UserTotalMoney.Add(values[1], decimal.Parse(values[4]) * -1);
                        Console.WriteLine(values[1]);
                    }
                    else
                    {
                        UserTotalMoney[values[1]] -= decimal.Parse(values[4]);
                    }
                    if (!UserTotalMoney.ContainsKey(values[2]))
                    {
                        UserTotalMoney.Add(values[2], decimal.Parse(values[4]));
                        Console.WriteLine(values[2]);
                    }
                    else
                    {
                        UserTotalMoney[values[2]] += decimal.Parse(values[4]);
                    }
                    }
            }
            foreach(KeyValuePair<string, decimal> entry in UserTotalMoney)
            {
                Console.WriteLine(entry);
            }

            return UserTotalMoney;
            }
        }
        
    }