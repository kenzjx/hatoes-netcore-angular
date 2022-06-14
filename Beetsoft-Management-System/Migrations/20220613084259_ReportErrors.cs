using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beetsoft_Management_System.Migrations
{
    public partial class ReportErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e977c85c-c306-4cd8-be80-e8fd610cf678");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9afc9155-7d6a-4a16-b846-56233a56e770");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d32a52d4-3081-4990-86cc-4553a5fc4905");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "68d8c750-c49f-4e65-9f3a-3d48819087bd");
        }
    }
}
