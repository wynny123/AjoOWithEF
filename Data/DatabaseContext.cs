using AjoOWithEF.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>

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
            base.OnModelCreating(builder);

           //called from the configurations class in the entities folder
            builder.ApplyConfiguration(new MemberConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new LoanConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());




        }

    }
}
