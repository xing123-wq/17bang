using Microsoft.EntityFrameworkCore.Migrations;

namespace _17bnag.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublishArticles_Users_AuthorId",
                table: "PublishArticles");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "PublishArticles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PublishArticles_Users_AuthorId",
                table: "PublishArticles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublishArticles_Users_AuthorId",
                table: "PublishArticles");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "PublishArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PublishArticles_Users_AuthorId",
                table: "PublishArticles",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
