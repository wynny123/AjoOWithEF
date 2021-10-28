using AjoOWithEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjoOWithEF.Configurations.Entities
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(
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
        }
    }
}
