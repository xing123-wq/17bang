using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelpRelease",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 10, nullable: false),
                    Body = table.Column<string>(maxLength: 21113, nullable: false),
                    Keywords = table.Column<string>(nullable: false),
                    Resort = table.Column<string>(nullable: true),
                    Moneys = table.Column<string>(nullable: false),
                    PublishDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpRelease", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 8, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublishArticles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    Body = table.Column<string>(maxLength: 2312412, nullable: false),
                    keywords = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: false),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    Digest = table.Column<string>(maxLength: 115, nullable: false),
                    Series = table.Column<string>(nullable: true),
                    UsedAds = table.Column<string>(nullable: true),
                    Interlinkage = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishArticles_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersMiddles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    HelpReleaseId = table.Column<int>(nullable: false)
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
                name: "IX_PublishArticles_AuthorId",
                table: "PublishArticles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersMiddles_UserId",
                table: "UsersMiddles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "PublishArticles");

            migrationBuilder.DropTable(
                name: "UsersMiddles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HelpRelease");
        }
    }
}
