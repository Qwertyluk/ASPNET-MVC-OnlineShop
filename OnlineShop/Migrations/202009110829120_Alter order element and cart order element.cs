namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alterorderelementandcartorderelement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderElement", "Order_OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderElement", "ProductElement_ProductId", "dbo.Product");
            DropIndex("dbo.OrderElement", new[] { "ProductElement_ProductId" });
            DropIndex("dbo.OrderElement", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.OrderElement", name: "Order_OrderId", newName: "OrderId");
            RenameColumn(table: "dbo.OrderElement", name: "ProductElement_ProductId", newName: "ProductId");
            CreateTable(
                "dbo.CartOrderElement",
                c => new
                    {
                        CartOrderElementId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        ProductElement_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CartOrderElementId)
                .ForeignKey("dbo.Product", t => t.ProductElement_ProductId)
                .Index(t => t.ProductElement_ProductId);
            
            AddColumn("dbo.OrderElement", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "UserId", c => c.String());
            AlterColumn("dbo.OrderElement", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderElement", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderElement", "OrderId");
            CreateIndex("dbo.OrderElement", "ProductId");
            AddForeignKey("dbo.OrderElement", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderElement", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderElement", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderElement", "OrderId", "dbo.Order");
            DropForeignKey("dbo.CartOrderElement", "ProductElement_ProductId", "dbo.Product");
            DropIndex("dbo.OrderElement", new[] { "ProductId" });
            DropIndex("dbo.OrderElement", new[] { "OrderId" });
            DropIndex("dbo.CartOrderElement", new[] { "ProductElement_ProductId" });
            AlterColumn("dbo.OrderElement", "OrderId", c => c.Int());
            AlterColumn("dbo.OrderElement", "ProductId", c => c.Int());
            DropColumn("dbo.Order", "UserId");
            DropColumn("dbo.OrderElement", "Value");
            DropTable("dbo.CartOrderElement");
            RenameColumn(table: "dbo.OrderElement", name: "ProductId", newName: "ProductElement_ProductId");
            RenameColumn(table: "dbo.OrderElement", name: "OrderId", newName: "Order_OrderId");
            CreateIndex("dbo.OrderElement", "Order_OrderId");
            CreateIndex("dbo.OrderElement", "ProductElement_ProductId");
            AddForeignKey("dbo.OrderElement", "ProductElement_ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.OrderElement", "Order_OrderId", "dbo.Order", "OrderId");
        }
    }
}
