using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beetsoft_Management_System.Migrations
{
    public partial class Testthu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8a882735-0c41-448e-acaa-96f25238e988");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3c11b71a-7ec4-418b-8728-2aa2420d317e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
