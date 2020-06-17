using System;
using System.Data.Entity.Migrations;
namespace Repositorys.Migrations
{
    public partial class addColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "InviterCode", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Inviter_Id", c => c.Int());
            CreateIndex("dbo.Users", "Inviter_Id");
            AddForeignKey("dbo.Users", "Inviter_Id", "dbo.Users", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "Inviter_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Inviter_Id" });
            DropColumn("dbo.Users", "Inviter_Id");
            DropColumn("dbo.Users", "InviterCode");
        }
    }
}