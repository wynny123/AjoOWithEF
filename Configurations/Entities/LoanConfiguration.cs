using AjoOWithEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Configurations.Entities
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasData(
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
