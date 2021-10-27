using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Data
{
    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; } //Member is class name and Members is the table name
        public DbSet<Account> Accounts { get; set; } //Account is the class name and Accounts is the table name
        public DbSet<Loan> Loans { get; set; } //Loan is the class name and Loans is the table name

        //seeding data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().HasData(
                new Member
                {
                    Id = 001,
                    FirstName = "Edwin",
                    Surname = "Ehiabhilyson",
                    ContactNo = "08108511957",
                    Email = "wynny123@gmail.com",
                    Department = "IT",
                    Address = "Addo round about, Ajah"
                },
                new Member
                {
                    Id = 002,
                    FirstName = "April",
                    Surname = "Edwin",
                    ContactNo = "08108511957",
                    Email = "apprill2221@gmail.com",
                    Department = "IT",
                    Address = "Addo round about, Ajah"
                },
                new Member
                {
                    Id = 003,
                    FirstName = "Moyo",
                    Surname = "Edwin",
                    ContactNo = "08108511957",
                    Email = "moyo@gmail.com",
                    Department = "Education",
                    Address = "Addo round about, Ajah"
                }

                );
            builder.Entity<Account>().HasData(
            new Account
                {
                    Id = 001,
                    Date = DateTime.ParseExact("2015-10-01", "yyyy-MM-dd", null),
                    Contribution = 20000,
                    LoanRepayment = 0,
                    Balance = 20000,
                    MemberId = 003,
                    
                },
                new Account
                {
                    Id = 234002,
                    Date = DateTime.ParseExact("2020-11-01", "yyyy-MM-dd", null),
                    Contribution = 30000,
                    LoanRepayment = 0,
                    Balance = 30000,
                    MemberId = 001,
                },
                new Account
                {
                    Id = 234003,
                    Date = DateTime.ParseExact("2019-11-01", "yyyy-MM-dd", null),
                    Contribution = 40000,
                    LoanRepayment = 0,
                    Balance = 40000,
                    MemberId = 002,
                }

                );
            builder.Entity<Loan>().HasData(
           new Loan
           {
               Id = 33001,
               Date = DateTime.ParseExact("2015-10-01", "yyyy-MM-dd", null),
               ApprovedBy = "Adewunmi Idris",
               Gurantor1 = "Chief Babatunde Ogwu",
               Gurantor2 = "Chief Mrs. Ronke Great",
               LoanAmount = 2000000,
               LoanRate = 7.5,
               MonthsOfRepayment = 24,
               MemberId = 002

    },
               new Loan
               {
                   Id = 33002,
                   Date = DateTime.ParseExact("2020-11-01", "yyyy-MM-dd", null),
                   ApprovedBy = "Adewunmi Idris",
                   Gurantor1 = "Chief Sunday Agbro",
                   Gurantor2 = "Mrs. Sikiratu Sindodo",
                   LoanAmount = 1000000,
                   LoanRate = 7.5,
                   MonthsOfRepayment = 24,
                   MemberId = 001
               },
               new Loan
               {
                   Id = 33003,
                   Date = DateTime.ParseExact("2019-11-01", "yyyy-MM-dd", null),
                   ApprovedBy = "Adewunmi Idris",
                   Gurantor1 = "Mr. Sunday Yusuf",
                   Gurantor2 = "Mr. Adefula Agbanikoko",
                   LoanAmount = 3000000,
                   LoanRate = 8.5,
                   MonthsOfRepayment = 30,
                   MemberId = 003
               }

               );

        }

    }
}
