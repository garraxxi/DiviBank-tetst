using System;

namespace loan_back.Models
{
    public class Client {
        public int Id { get; set; }
        public string Names { get; set; }
        public DateTime? BirthDate { get; set; }
        public Client(int id, string names) {
            this.Id = id;
            this.Names = names;
            this.BirthDate = new DateTime();
        }
    }
}