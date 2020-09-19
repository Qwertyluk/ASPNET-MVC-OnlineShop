namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcategoryidtoproductmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductCategory_CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "ProductCategory_CategoryId" });
            RenameColumn(table: "dbo.Product", name: "ProductCategory_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Product", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            AlterColumn("dbo.Product", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "CategoryId", newName: "ProductCategory_CategoryId");
            CreateIndex("dbo.Product", "ProductCategory_CategoryId");
            AddForeignKey("dbo.Product", "ProductCategory_CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
