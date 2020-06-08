using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class NotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpMony",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ValidatePassword",
                table: "OnModel");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "OnModel");

            migrationBuilder.AlterColumn<string>(
                name: "inviter",
                table: "OnModel",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Invitationcode",
                table: "OnModel",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HelpMony",
                table: "OnModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "OnModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpMony",
                table: "OnModel");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "OnModel");

            migrationBuilder.AddColumn<int>(
                name: "HelpMony",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "inviter",
                table: "OnModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Invitationcode",
                table: "OnModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AddColumn<string>(
                name: "ValidatePassword",
                table: "OnModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "OnModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
