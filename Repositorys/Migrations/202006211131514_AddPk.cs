namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPk : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProblemAndKeywords");
            AlterColumn("dbo.ProblemAndKeywords", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProblemAndKeywords", new[] { "ProblemId", "KeywordId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProblemAndKeywords");
            AlterColumn("dbo.ProblemAndKeywords", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ProblemAndKeywords", "Id");
        }
    }
}
