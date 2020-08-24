namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageNamefieldtoProductmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageName");
        }
    }
}
