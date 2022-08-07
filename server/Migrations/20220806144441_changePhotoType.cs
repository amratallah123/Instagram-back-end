using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class changePhotoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c88139bc-1cab-41e0-ba6a-aa94287cce05"));

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "Email", "FirstName", "LastName", "Mobile", "Password", "UserName" },
                values: new object[] { new Guid("251bca70-d1bc-4d0d-ac46-7466d2f752af"), null, "I am a software engineer", "amr.atallahh147@gmail.com", "Amr", "Atallah", "+201145517449", "AmrAtallah", "amratallah" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("251bca70-d1bc-4d0d-ac46-7466d2f752af"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Bio", "Email", "FirstName", "LastName", "Mobile", "Password", "UserName" },
                values: new object[] { new Guid("c88139bc-1cab-41e0-ba6a-aa94287cce05"), null, "I am a software engineer", "amr.atallahh147@gmail.com", "Amr", "Atallah", "+201145517449", "AmrAtallah", "amratallah" });
        }
    }
}
