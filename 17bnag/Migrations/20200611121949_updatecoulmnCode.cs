using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class updatecoulmnCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invitationcode",
                table: "onModels");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "onModels",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "onModels");

            migrationBuilder.AddColumn<string>(
                name: "Invitationcode",
                table: "onModels",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }
    }
}
