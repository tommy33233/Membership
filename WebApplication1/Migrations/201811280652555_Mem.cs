namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 2048),
                        Url = c.String(maxLength: 1024),
                        ImageUrl = c.String(maxLength: 1024),
                        HTML = c.String(),
                        WaitDays = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        IsFree = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Item_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.Item_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.ProductItem",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ItemId });
            
            CreateTable(
                "dbo.ProductLinkText",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ImageUrl = c.String(maxLength: 1024),
                        Description = c.String(maxLength: 2048),
                        ProductLinkTextId = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionProduct",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Subscription = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Subscription });
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 2048),
                        RegistrationCode = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSubscription",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.SubscriptionId, t.UserId });
            
            AddColumn("dbo.Section", "Item_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Registered", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Section", "Item_Id");
            AddForeignKey("dbo.Section", "Item_Id", "dbo.Item", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Section", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.Part", "Item_Id", "dbo.Item");
            DropForeignKey("dbo.ItemType", "Item_Id", "dbo.Item");
            DropIndex("dbo.Section", new[] { "Item_Id" });
            DropIndex("dbo.Part", new[] { "Item_Id" });
            DropIndex("dbo.ItemType", new[] { "Item_Id" });
            DropColumn("dbo.AspNetUsers", "Registered");
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Section", "Item_Id");
            DropTable("dbo.UserSubscription");
            DropTable("dbo.Subscription");
            DropTable("dbo.SubscriptionProduct");
            DropTable("dbo.ProductType");
            DropTable("dbo.Product");
            DropTable("dbo.ProductLinkText");
            DropTable("dbo.ProductItem");
            DropTable("dbo.Part");
            DropTable("dbo.ItemType");
            DropTable("dbo.Item");
        }
    }
}
