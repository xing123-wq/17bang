using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class addTABLEKEYWORDMIDDLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleMap_PublishArticles_ArticleId",
                table: "ArticleMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleMap_Keywords_KeywordId",
                table: "ArticleMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleMap",
                table: "ArticleMap");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "HelpRelease");

            migrationBuilder.RenameTable(
                name: "ArticleMap",
                newName: "ArticleMaps");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleMap_KeywordId",
                table: "ArticleMaps",
                newName: "IX_ArticleMaps_KeywordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleMaps",
                table: "ArticleMaps",
                columns: new[] { "ArticleId", "KeywordId" });

            migrationBuilder.CreateTable(
                name: "KeywordMiddles",
                columns: table => new
                {
                    HelpReleaseId = table.Column<int>(nullable: false),
                    KeywordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordMiddles", x => new { x.HelpReleaseId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_KeywordMiddles_HelpRelease_HelpReleaseId",
                        column: x => x.HelpReleaseId,
                        principalTable: "HelpRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordMiddles_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordMiddles_KeywordId",
                table: "KeywordMiddles",
                column: "KeywordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleMaps_PublishArticles_ArticleId",
                table: "ArticleMaps",
                column: "ArticleId",
                principalTable: "PublishArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleMaps_Keywords_KeywordId",
                table: "ArticleMaps",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleMaps_PublishArticles_ArticleId",
                table: "ArticleMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleMaps_Keywords_KeywordId",
                table: "ArticleMaps");

            migrationBuilder.DropTable(
                name: "KeywordMiddles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleMaps",
                table: "ArticleMaps");

            migrationBuilder.RenameTable(
                name: "ArticleMaps",
                newName: "ArticleMap");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleMaps_KeywordId",
                table: "ArticleMap",
                newName: "IX_ArticleMap_KeywordId");

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "HelpRelease",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleMap",
                table: "ArticleMap",
                columns: new[] { "ArticleId", "KeywordId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleMap_PublishArticles_ArticleId",
                table: "ArticleMap",
                column: "ArticleId",
                principalTable: "PublishArticles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleMap_Keywords_KeywordId",
                table: "ArticleMap",
                column: "KeywordId",
                principalTable: "Keywords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
