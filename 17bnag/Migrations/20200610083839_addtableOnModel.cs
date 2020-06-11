using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class addtableOnModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnModel",
                table: "OnModel");

            migrationBuilder.RenameTable(
                name: "OnModel",
                newName: "onModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_onModels",
                table: "onModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_onModels_OnModelId",
                table: "Users",
                column: "OnModelId",
                principalTable: "onModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_onModels_OnModelId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_onModels",
                table: "onModels");

            migrationBuilder.RenameTable(
                name: "onModels",
                newName: "OnModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnModel",
                table: "OnModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users",
                column: "OnModelId",
                principalTable: "OnModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
