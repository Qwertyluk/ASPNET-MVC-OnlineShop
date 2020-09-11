namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addorderelementtoordermodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderElement",
                c => new
                    {
                        OrderElementId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ProductElement_ProductId = c.Int(),
                        Order_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderElementId)
                .ForeignKey("dbo.Product", t => t.ProductElement_ProductId)
                .ForeignKey("dbo.Order", t => t.Order_OrderId)
                .Index(t => t.ProductElement_ProductId)
                .Index(t => t.Order_OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderElement", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderElement", "ProductElement_ProductId", "dbo.Product");
            DropIndex("dbo.OrderElement", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderElement", new[] { "ProductElement_ProductId" });
            DropTable("dbo.OrderElement");
        }
    }
}
