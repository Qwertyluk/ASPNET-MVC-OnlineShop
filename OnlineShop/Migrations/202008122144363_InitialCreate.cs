namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        PurchaserName = c.String(nullable: false, maxLength: 50),
                        PurchaserSurname = c.String(nullable: false, maxLength: 50),
                        PurchaserStreet = c.String(nullable: false, maxLength: 50),
                        PurchaserCity = c.String(nullable: false, maxLength: 50),
                        PurchaserPhoneNumber = c.String(nullable: false),
                        PurchaserEmail = c.String(),
                        Comment = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        StateOfOrder = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Brand = c.String(maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSold = c.Boolean(nullable: false),
                        IsOnSale = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.Category");
        }
    }
}
