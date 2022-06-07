namespace SupportBank {
    class TransactionJson {
        public DateTime Date {get; set;} 
        public string FromAccount {get; set; }
        public string ToAccount {get; set;}
        public string Narrative {get; set;}
        public decimal Amount {get; set; }

        // public TransactionJson (DateTime date, string from, string to, string narrative, decimal amount)
        // {
        //     Date = date;
        //     FromAccount = from;
        //     ToAccount = to;
        //     Narrative = narrative;
        //     Amount = amount;
        // }

    }
}