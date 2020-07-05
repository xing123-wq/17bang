namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoulmnauthorid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Series", "Author_Id", "dbo.Users");
            DropIndex("dbo.Series", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Series", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Series", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Series", "AuthorId");
            AddForeignKey("dbo.Series", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "AuthorId", "dbo.Users");
            DropIndex("dbo.Series", new[] { "AuthorId" });
            AlterColumn("dbo.Series", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Series", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Series", "Author_Id");
            AddForeignKey("dbo.Series", "Author_Id", "dbo.Users", "Id");
        }
    }
}
