using System;

namespace loan_back.Models
{
    public class Loan {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Interest { get; set; }
        public int Term { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClientId { get; set; }

        public Loan(int id,
            double amount,
            double interest,
            int term,
            int customerId)
        {
            this.Id = id;
            this.Amount = amount;
            this.Interest = interest;
            this.Term = term;
            this.ClientId = customerId;
            this.CreatedDate = new DateTime();
        }
    }
}