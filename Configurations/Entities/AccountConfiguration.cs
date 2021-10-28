using AjoOWithEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Configurations.Entities
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
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
        }
    }
}
