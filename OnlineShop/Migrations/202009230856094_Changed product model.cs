namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedproductmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Brand", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Brand", c => c.String(maxLength: 50));
        }
    }
}
