using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.Infrastructure.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OnlineShop.DAL
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext() : base("ShopContext") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartOrderElement> OrderElements { get; set; }

        static ShopContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public static ShopContext Create() 
        {
            return new ShopContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Prevent adding 's' on the end of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}