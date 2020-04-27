using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class ffg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValidatePassword",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inviter",
                table: "Users",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidatePassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "inviter",
                table: "Users");
        }
    }
}
