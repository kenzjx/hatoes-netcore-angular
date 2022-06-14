using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beetsoft_Management_System.Migrations
{
    public partial class Testthu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e89a0be7-4e98-4ff8-a383-8bdff4e72486");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d90f2276-3b64-4973-8dd3-5594c3ebc81b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c2956976-9027-40f8-983f-2e96e8691d3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "90144d17-3742-4aa0-8410-99852983b2c4");
        }
    }
}
