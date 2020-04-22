using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class wen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersMiddles");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRelease_UserId",
                table: "HelpRelease",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpRelease_Users_UserId",
                table: "HelpRelease",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpRelease_Users_UserId",
                table: "HelpRelease");

            migrationBuilder.DropIndex(
                name: "IX_HelpRelease_UserId",
                table: "HelpRelease");

            migrationBuilder.CreateTable(
                name: "UsersMiddles",
                columns: table => new
                {
                    HelpReleaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMiddles", x => new { x.HelpReleaseId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersMiddles_Users_HelpReleaseId",
                        column: x => x.HelpReleaseId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersMiddles_HelpRelease_UserId",
                        column: x => x.UserId,
                        principalTable: "HelpRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersMiddles_UserId",
                table: "UsersMiddles",
                column: "UserId");
        }
    }
}
