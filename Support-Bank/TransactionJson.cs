namespace SupportBank {
    class TransactionJson {
        public DateTime Date {get;} 
        public string FromAccount {get;}
        public string ToAccount {get;}
        public string Narrative {get;}
        public decimal Amount {get; }

        public TransactionJson (DateTime date, string from, string to, string narrative, decimal amount)
        {
            Date = date;
            FromAccount = from;
            ToAccount = to;
            Narrative = narrative;
            Amount = amount;
        }

    }
}