namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changestreetandcityintoaddressandpostcodeinorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "PurchaserAdress", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "PurchaserPostCode", c => c.String(nullable: false));
            DropColumn("dbo.Order", "PurchaserStreet");
            DropColumn("dbo.Order", "PurchaserCity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "PurchaserCity", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "PurchaserStreet", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Order", "PurchaserPostCode");
            DropColumn("dbo.Order", "PurchaserAdress");
        }
    }
}
