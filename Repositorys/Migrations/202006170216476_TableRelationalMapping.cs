namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRelationalMapping : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ArticleAndKeywords");
            DropPrimaryKey("dbo.ProblemAndKeywords");
            AlterColumn("dbo.ArticleAndKeywords", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProblemAndKeywords", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ArticleAndKeywords", new[] { "ArticleId", "KeywordId" });
            AddPrimaryKey("dbo.ProblemAndKeywords", new[] { "ProblemId", "KeywordId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProblemAndKeywords");
            DropPrimaryKey("dbo.ArticleAndKeywords");
            AlterColumn("dbo.ProblemAndKeywords", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ArticleAndKeywords", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProblemAndKeywords", "Id");
            AddPrimaryKey("dbo.ArticleAndKeywords", "Id");
        }
    }
}
