using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMitra.Migrations
{
    public partial class roleSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e54acc6-d275-4f9f-83b7-b15fa43a4324", "1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3805a12e-1362-426f-a8c0-8ae7b95dc511", "2", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e54acc6-d275-4f9f-83b7-b15fa43a4324");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3805a12e-1362-426f-a8c0-8ae7b95dc511");
        }
    }
}
