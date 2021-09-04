using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace loan_back.Models
{
    public class BankDbContext : DbContext
    {
        public DbSet<Client> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public BankDbContext(DbContextOptions<BankDbContext> options):base(options)
        {

        }

        public async Task<List<Client>> GetClientsAsync() => await Customers.ToListAsync<Client>();
        public async Task AddCustomerAsync(Client customer)
        {
            await Customers.AddAsync(customer);
            this.SaveChanges();
            return;
        }

        internal async Task<Client> GetClientByIdAsync(int id) => await Customers.FindAsync(id);

        internal async Task<bool> ClientUpdateAsync(Client customer)
        {
            var cstmr = await GetClientByIdAsync(customer.Id);
            if(cstmr == null)
            {
                return false;
            }
            cstmr.Names = customer.Names;
            cstmr.BirthDate = customer.BirthDate;
            Customers.Update(cstmr);
            this.SaveChanges();
            return true;
        }

        internal async Task<bool> ClientDeleteAsync(int id) 
        {
            var customer = await Customers.FindAsync(id);
            Customers.Remove(customer);
            this.SaveChanges();
            return true;
        }

        internal async Task AddLoanAsync(Loan loan)
        {
            await Loans.AddAsync(loan);
            this.SaveChanges();
            return;
        }

        public async Task<List<Loan>> GetLoanssAsync() => await Loans.ToListAsync<Loan>();

        internal async Task<bool> LoanUpdateAsync(Loan loan)
        {
            var ln = await GetLoanByIdAsync(loan.Id);
            if (loan == null)
            {
                return false;
            }
            var cstmr = await GetClientByIdAsync(loan.ClientId);
            if (cstmr == null)
            {
                return false;
            }
            ln.Amount = loan.Amount;
            ln.Interest = loan.Interest;
            ln.Term = loan.Term;
            ln.ClientId = loan.ClientId;
            Loans.Update(ln);
            this.SaveChanges();
            return true;
        }

        internal async Task<bool> LoanDeleteAsync(int id)
        {
            var loan = await Loans.FindAsync(id);
            Loans.Remove(loan);
            this.SaveChanges();
            return true;
        }

        internal async Task<Loan> GetLoanByIdAsync(int id) => await Loans.FindAsync(id);
    }
}
