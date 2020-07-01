namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDetaBese : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        InviterId = c.Int(),
                        InviterCode = c.String(),
                        WalletId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.InviterId)
                .Index(t => t.InviterId);
            
            CreateTable(
                "dbo.Advertisings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Advertising_Id = c.Int(),
                        Series_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisings", t => t.Advertising_Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.Series_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.Advertising_Id)
                .Index(t => t.Series_Id);
            
            CreateTable(
                "dbo.ArticleAndKeywords",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.KeywordId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Keywords", t => t.KeywordId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.KeywordId);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Counter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProblemAndKeywords",
                c => new
                    {
                        ProblemId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProblemId, t.KeywordId })
                .ForeignKey("dbo.Keywords", t => t.KeywordId, cascadeDelete: true)
                .ForeignKey("dbo.Problems", t => t.ProblemId, cascadeDelete: true)
                .Index(t => t.ProblemId)
                .Index(t => t.KeywordId);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishTime = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
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
                .ForeignKey("dbo.Series", t => t.FatherSeries_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.FatherSeries_Id);
            
            CreateTable(
                "dbo.BanMoneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BanCoin = c.Int(),
                        SpendingTime = c.DateTime(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BanMoneys", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Users", "InviterId", "dbo.Users");
            DropForeignKey("dbo.Advertisings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Series_Id", "dbo.Series");
            DropForeignKey("dbo.Series", "FatherSeries_Id", "dbo.Series");
            DropForeignKey("dbo.Series", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.ProblemAndKeywords", "ProblemId", "dbo.Problems");
            DropForeignKey("dbo.Problems", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.ProblemAndKeywords", "KeywordId", "dbo.Keywords");
            DropForeignKey("dbo.ArticleAndKeywords", "KeywordId", "dbo.Keywords");
            DropForeignKey("dbo.ArticleAndKeywords", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Articles", "Advertising_Id", "dbo.Advertisings");
            DropIndex("dbo.BanMoneys", new[] { "OwnerId" });
            DropIndex("dbo.Series", new[] { "FatherSeries_Id" });
            DropIndex("dbo.Series", new[] { "Author_Id" });
            DropIndex("dbo.Problems", new[] { "AuthorId" });
            DropIndex("dbo.ProblemAndKeywords", new[] { "KeywordId" });
            DropIndex("dbo.ProblemAndKeywords", new[] { "ProblemId" });
            DropIndex("dbo.ArticleAndKeywords", new[] { "KeywordId" });
            DropIndex("dbo.ArticleAndKeywords", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "Series_Id" });
            DropIndex("dbo.Articles", new[] { "Advertising_Id" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropIndex("dbo.Advertisings", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "InviterId" });
            DropTable("dbo.BanMoneys");
            DropTable("dbo.Series");
            DropTable("dbo.Problems");
            DropTable("dbo.ProblemAndKeywords");
            DropTable("dbo.Keywords");
            DropTable("dbo.ArticleAndKeywords");
            DropTable("dbo.Articles");
            DropTable("dbo.Advertisings");
            DropTable("dbo.Users");
        }
    }
}
