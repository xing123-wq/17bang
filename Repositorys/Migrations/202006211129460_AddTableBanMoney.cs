namespace Repositorys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBanMoney : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Users", "WalletId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BanMoneys", "OwnerId", "dbo.Users");
            DropIndex("dbo.BanMoneys", new[] { "OwnerId" });
            DropColumn("dbo.Users", "WalletId");
            DropTable("dbo.BanMoneys");
        }
    }
}
