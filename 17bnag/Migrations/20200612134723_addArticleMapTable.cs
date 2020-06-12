using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class addArticleMapTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "keywords",
                table: "PublishArticles");

            migrationBuilder.CreateTable(
                name: "ArticleMap",
                columns: table => new
                {
                    KeywordId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleMap", x => new { x.ArticleId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_ArticleMap_PublishArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "PublishArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleMap_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleMap_KeywordId",
                table: "ArticleMap",
                column: "KeywordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleMap");

            migrationBuilder.AddColumn<string>(
                name: "keywords",
                table: "PublishArticles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
