using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beetsoft_Management_System.Migrations
{
    public partial class ReportError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "dfbed1b2-43c2-4e1a-8d9d-f594ce284e9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "46032162-67a9-4804-8697-67a01117d86a");
        }
    }
}
