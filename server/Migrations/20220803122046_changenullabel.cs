using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class changenullabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be722622-4962-4893-80b6-6c67d3b8229e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "Email", "FirstName", "LastName", "Mobile", "Password", "UserName" },
                values: new object[] { new Guid("fddf16bb-9ddf-4359-accb-758408444003"), null, "I am a software engineer", "amr.atallahh147@gmail.com", "Amr", "Atallah", "+201145517449", "AmrAtallah", "amratallah" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fddf16bb-9ddf-4359-accb-758408444003"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "Email", "FirstName", "LastName", "Mobile", "Password", "UserName" },
                values: new object[] { new Guid("be722622-4962-4893-80b6-6c67d3b8229e"), null, "I am a software engineer", "amr.atallahh147@gmail.com", "Amr", "Atallah", "+201145517449", "AmrAtallah", "amratallah" });
        }
    }
}
