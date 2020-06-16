namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
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
                "dbo.ArticleAndKeywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
                        Id = c.Int(nullable: false, identity: true),
                        ProblemId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProblemAndKeywords", "ProblemId", "dbo.Problems");
            DropForeignKey("dbo.Problems", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.ProblemAndKeywords", "KeywordId", "dbo.Keywords");
            DropForeignKey("dbo.ArticleAndKeywords", "KeywordId", "dbo.Keywords");
            DropForeignKey("dbo.ArticleAndKeywords", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Users");
            DropIndex("dbo.Problems", new[] { "AuthorId" });
            DropIndex("dbo.ProblemAndKeywords", new[] { "KeywordId" });
            DropIndex("dbo.ProblemAndKeywords", new[] { "ProblemId" });
            DropIndex("dbo.ArticleAndKeywords", new[] { "KeywordId" });
            DropIndex("dbo.ArticleAndKeywords", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropTable("dbo.Problems");
            DropTable("dbo.ProblemAndKeywords");
            DropTable("dbo.Keywords");
            DropTable("dbo.ArticleAndKeywords");
            DropTable("dbo.Articles");
            DropTable("dbo.Users");
        }
    }
}
