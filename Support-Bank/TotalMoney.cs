namespace SupportBank
{
    class TotalMoney
    {
        public Dictionary <string,decimal> UserTotalMoney {get; set;} = new Dictionary<string, decimal>();
        
        public Dictionary <string,decimal> CreateUserTotalMoney()
        {
            using (var reader = new StreamReader("DodgyTransactions2015.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');
                    try
                        {
                           decimal passAmount = decimal.Parse(values[4]);
                        }
                        catch (FormatException exception)
                        {
                            Console.WriteLine($"The transaction from {values[1]} to {values[2]} on date {values[0]} has invalid amount.");
                            continue;
                        }
                    if (!UserTotalMoney.ContainsKey(values[1]))
                    {
                        UserTotalMoney.Add(values[1], decimal.Parse(values[4]) * -1);;
                    }
                    else
                    {
                        UserTotalMoney[values[1]] -= decimal.Parse(values[4]);
                    }
                    if (!UserTotalMoney.ContainsKey(values[2]))
                    {
                        UserTotalMoney.Add(values[2], decimal.Parse(values[4]));
                    }
                    else
                    {
                        UserTotalMoney[values[2]] += decimal.Parse(values[4]);
                    }
                    }
            }
            foreach(KeyValuePair<string, decimal> entry in UserTotalMoney)
            {
                var textColor = entry.Value >=0 ? Console.ForegroundColor=ConsoleColor.Green : Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine($"{entry.Key} ballance is £{entry.Value}");
            }

            return UserTotalMoney;
            }
        }
        
    }