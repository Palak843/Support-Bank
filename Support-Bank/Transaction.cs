namespace SupportBank {
    class Transaction {
        public DateTime Date {get;}
        public string From {get ;}
        public string To {get ;}
        public string Narrative {get ;}
        public decimal Amount {get; }

        public Transaction (DateTime date, string from, string to, string narrative, decimal amount)
        {
            DateTime Date = date;
            string From = from;
            string To = to;
            string Narrative = narrative;
            decimal Amount = amount;
        }


    }
}