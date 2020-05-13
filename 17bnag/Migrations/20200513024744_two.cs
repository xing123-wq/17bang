using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_OnModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OnModelId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "inviter",
                table: "OnModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "OnModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "ValidatePassword",
                table: "OnModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Invitationcode",
                table: "OnModel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OnModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OnModel_UserId",
                table: "OnModel",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OnModel_Users_UserId",
                table: "OnModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnModel_Users_UserId",
                table: "OnModel");

            migrationBuilder.DropIndex(
                name: "IX_OnModel_UserId",
                table: "OnModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OnModel");

            migrationBuilder.AddColumn<int>(
                name: "OnModelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "inviter",
                table: "OnModel",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VerificationCode",
                table: "OnModel",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ValidatePassword",
                table: "OnModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Invitationcode",
                table: "OnModel",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OnModelId",
                table: "Users",
                column: "OnModelId");

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
