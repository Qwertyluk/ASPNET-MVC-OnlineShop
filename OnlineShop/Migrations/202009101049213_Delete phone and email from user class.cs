namespace OnlineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletephoneandemailfromuserclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "User_Email");
            DropColumn("dbo.AspNetUsers", "User_Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "User_Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "User_Email", c => c.String(nullable: false));
        }
    }
}
