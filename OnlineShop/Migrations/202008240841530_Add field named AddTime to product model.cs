namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfieldnamedAddTimetoproductmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "AddTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "AddTime");
        }
    }
}
