namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedvirtualpropertytoproductmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ProductCategory_CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "ProductCategory_CategoryId");
            AddForeignKey("dbo.Product", "ProductCategory_CategoryId", "dbo.Category", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductCategory_CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "ProductCategory_CategoryId" });
            DropColumn("dbo.Product", "ProductCategory_CategoryId");
        }
    }
}
