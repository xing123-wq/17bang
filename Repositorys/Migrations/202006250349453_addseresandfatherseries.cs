namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addseresandfatherseries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FatherSeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Describe = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Describe = c.String(),
                        Author_Id = c.Int(),
                        FatherSeries_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.FatherSeries", t => t.FatherSeries_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.FatherSeries_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "FatherSeries_Id", "dbo.FatherSeries");
            DropForeignKey("dbo.Series", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.FatherSeries", "Author_Id", "dbo.Users");
            DropIndex("dbo.Series", new[] { "FatherSeries_Id" });
            DropIndex("dbo.Series", new[] { "Author_Id" });
            DropIndex("dbo.FatherSeries", new[] { "Author_Id" });
            DropTable("dbo.Series");
            DropTable("dbo.FatherSeries");
        }
    }
}
