namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumnInviterId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "InviterId" });
            AlterColumn("dbo.Users", "InviterId", c => c.Int());
            CreateIndex("dbo.Users", "InviterId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "InviterId" });
            AlterColumn("dbo.Users", "InviterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "InviterId");
        }
    }
}
