using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class addFKId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "OnModelId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HelpReleaseId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotitcesId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublishArticlesId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users",
                column: "OnModelId",
                principalTable: "OnModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HelpReleaseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NotitcesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PublishArticlesId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "OnModelId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users",
                column: "OnModelId",
                principalTable: "OnModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
