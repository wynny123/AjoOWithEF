using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AjoOWithEF.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "ContactNo", "Department", "Email", "FirstName", "Surname" },
                values: new object[] { 1, "Addo round about, Ajah", "08108511957", "IT", "wynny123@gmail.com", "Edwin", "Ehiabhilyson" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "ContactNo", "Department", "Email", "FirstName", "Surname" },
                values: new object[] { 2, "Addo round about, Ajah", "08108511957", "IT", "apprill2221@gmail.com", "April", "Edwin" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "ContactNo", "Department", "Email", "FirstName", "Surname" },
                values: new object[] { 3, "Addo round about, Ajah", "08108511957", "Education", "moyo@gmail.com", "Moyo", "Edwin" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "Contribution", "Date", "LoanRepayment", "MemberId" },
                values: new object[,]
                {
                    { 234002, 30000.0, 30000.0, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 1 },
                    { 234003, 40000.0, 40000.0, new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 2 },
                    { 1, 20000.0, 20000.0, new DateTime(2015, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "ApprovedBy", "Date", "Gurantor1", "Gurantor2", "LoanAmount", "LoanRate", "MemberId", "MonthsOfRepayment" },
                values: new object[,]
                {
                    { 33002, "Adewunmi Idris", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Sunday Agbro", "Mrs. Sikiratu Sindodo", 1000000.0, 7.5, 1, 24.0 },
                    { 33001, "Adewunmi Idris", new DateTime(2015, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Babatunde Ogwu", "Chief Mrs. Ronke Great", 2000000.0, 7.5, 2, 24.0 },
                    { 33003, "Adewunmi Idris", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr. Sunday Yusuf", "Mr. Adefula Agbanikoko", 3000000.0, 8.5, 3, 30.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 234002);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 234003);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 33001);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 33002);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 33003);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
