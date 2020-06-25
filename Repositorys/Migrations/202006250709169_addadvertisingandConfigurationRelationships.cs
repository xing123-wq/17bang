namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadvertisingandConfigurationRelationships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Articles", "Advertising_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Advertising_Id");
            AddForeignKey("dbo.Articles", "Advertising_Id", "dbo.Advertisings", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertisings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "Advertising_Id", "dbo.Advertisings");
            DropIndex("dbo.Articles", new[] { "Advertising_Id" });
            DropIndex("dbo.Advertisings", new[] { "User_Id" });
            DropColumn("dbo.Articles", "Advertising_Id");
            DropTable("dbo.Advertisings");
        }
    }
}
