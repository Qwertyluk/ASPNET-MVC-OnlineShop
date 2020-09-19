namespace OnlineShop.Migrations
{
    using OnlineShop.DAL;
    using OnlineShop.Infrastructure.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineShop.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineShop.DAL.ShopContext";
        }

        protected override void Seed(OnlineShop.DAL.ShopContext context)
        {
            DatabaseInitializer.SeedCategories(context);
            DatabaseInitializer.SeedProducts(context);
            DatabaseInitializer.SeedUsers(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
