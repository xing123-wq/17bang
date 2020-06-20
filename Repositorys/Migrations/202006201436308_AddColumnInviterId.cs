namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInviterId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Inviter_Id" });
            RenameColumn(table: "dbo.Users", name: "Inviter_Id", newName: "InviterId");
            AlterColumn("dbo.Users", "InviterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "InviterId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "InviterId" });
            AlterColumn("dbo.Users", "InviterId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "InviterId", newName: "Inviter_Id");
            CreateIndex("dbo.Users", "Inviter_Id");
        }
    }
}
