namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisings", "PublishTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Advertisings", "Expires", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisings", "Expires");
            DropColumn("dbo.Advertisings", "PublishTime");
        }
    }
}
