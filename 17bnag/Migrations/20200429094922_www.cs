using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class www : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invitationcode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ValidatePassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "inviter",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "OnModelId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OnModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invitationcode = table.Column<string>(maxLength: 4, nullable: false),
                    inviter = table.Column<string>(maxLength: 8, nullable: false),
                    ValidatePassword = table.Column<string>(nullable: false),
                    VerificationCode = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnModel", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OnModel_OnModelId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "OnModel");

            migrationBuilder.DropIndex(
                name: "IX_Users_OnModelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OnModelId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Invitationcode",
                table: "Users",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValidatePassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Users",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inviter",
                table: "Users",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
