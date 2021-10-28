using Microsoft.EntityFrameworkCore.Migrations;

namespace AjoOWithEF.Migrations
{
    public partial class AddedDefaultRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5ffcc71-7413-49f4-9226-041ad0ff6e4f", "b6766182-999b-4a88-968a-81e73d270652", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "201c9f33-3f5f-415c-907c-de0b3e75ee55", "fb6d9076-b77d-463c-945f-1e670ed251ff", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "201c9f33-3f5f-415c-907c-de0b3e75ee55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5ffcc71-7413-49f4-9226-041ad0ff6e4f");
        }
    }
}
