using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.DAL;
using OnlineShop.Migrations;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure.DAL
{
    public class DatabaseInitializer : MigrateDatabaseToLatestVersion<ShopContext, Configuration>
    {
        public static void SeedProducts(ShopContext context)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product()
            {
                ProductId = 1,
                Name = "Pilka Baseball",
                Brand = "Baseball ball company",
                Description = "Pilka do gry w baseball",
                Price = 10.00m,
                IsSold = false,
                IsOnSale = true,
                AddTime = new DateTime(2020, 9, 17, 10, 0, 0),
                ImageName = "baseball_ball.jpg",
                CategoryId = 1
            });
            products.Add(new Product()
            {
                ProductId = 2,
                Name = "Rekawice baseball",
                Brand = "Baseball glove company",
                Description = "Rekawice do gry w baseball",
                Price = 20.00m,
                IsSold = false,
                IsOnSale = true,
                AddTime = new DateTime(2020, 9, 17, 11, 0, 0),
                ImageName = "baseball_glove.jpg",
                CategoryId = 1
            });
            products.Add(new Product()
            {
                ProductId = 3,
                Name = "Rekawice boks",
                Brand = "Boxing glove company",
                Description = "Rekawice do boxu",
                Price = 40.00m,
                IsSold = false,
                IsOnSale = true,
                AddTime = new DateTime(2020, 9, 17, 12, 0, 0),
                ImageName = "boxing_glove.jpg",
                CategoryId = 2
            });
            products.Add(new Product()
            {
                ProductId = 4,
                Name = "Pilka Football",
                Brand = "Football ball company",
                Description = "Pilka do gry w football",
                Price = 50.00m,
                IsSold = false,
                IsOnSale = false,
                AddTime = new DateTime(2020, 9, 17, 13, 0, 0),
                ImageName = "football_ball.jpg",
                CategoryId = 3
            });
            products.Add(new Product()
            {
                ProductId = 5,
                Name = "Pilka Soccer",
                Brand = "Soccer ball company",
                Description = "Pilka do gry w soccer",
                Price = 60.00m,
                IsSold = false,
                IsOnSale = false,
                AddTime = new DateTime(2020, 9, 17, 14, 0, 0),
                ImageName = "soccer_ball.jpg",
                CategoryId = 4
            });
            products.Add(new Product()
            {
                ProductId = 6,
                Name = "Rower",
                Brand = "Bicycle company",
                Description = "Rower do jazdy",
                Price = 30.00m,
                IsSold = false,
                IsOnSale = true,
                AddTime = new DateTime(2020, 9, 17, 12, 30, 0),
                ImageName = "bicycle.jpg",
                CategoryId = 5
            });

            products.ForEach(p => context.Products.AddOrUpdate(p));
            context.SaveChanges();
        }

        public static void SeedCategories(ShopContext context)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                CategoryId = 1,
                Name = "Baseball",
                Description = "Opis Baseball"
            });
            categories.Add(new Category()
            {
                CategoryId = 2,
                Name = "Boks",
                Description = "Opis Boksu"
            });
            categories.Add(new Category()
            {
                CategoryId = 3,
                Name = "Football",
                Description = "Opis Footballu"
            });
            categories.Add(new Category()
            {
                CategoryId = 4,
                Name = "Pilka nozna",
                Description = "Opis Pilki Noznej"
            });
            categories.Add(new Category()
            {
                CategoryId = 5,
                Name = "Kolarstwo",
                Description = "Opis Kolarstwa"
            });

            categories.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();
        }

        public static void SeedUsers(ShopContext context)
        {
            CreateAdminUser(context);
            CreateNormalUser(context);
        }

        private static void CreateAdminUser(ShopContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string userName = "Admin";
            var user = userManager.FindByName(userName);

            bool userExists = false;
            if (user is null)
            {
                //If the user does not exist, create a new user
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = "admin@admin.pl",
                    PhoneNumber = "111222333",
                    User = new User()
                    {
                        Name = "Imie",
                        Surname = "Nazwisko",
                        Adress = "Katowice",
                        PostCode = "42-500",
                    }
                };

                var result = userManager.Create(user, "password");
                if (result.Succeeded)
                    userExists = true;
            }
            else
                userExists = true;

            //Create role manager
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = "Admin";
            var role = roleManager.FindByName(roleName);

            bool roleExists = false;
            if (role is null)
            {
                //Create role
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);

                if (roleResult.Succeeded)
                    roleExists = true;
            }
            else
                roleExists = true;

            if (userExists && roleExists)
            {
                if (!userManager.GetRoles(user.Id).Contains("Admin"))
                    userManager.AddToRole(user.Id, role.Name);
            }
        }

        private static void CreateNormalUser(ShopContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string userName = "User";
            var user = userManager.FindByName(userName);

            if (user is null)
            {
                //If the user does not exist, create a new user
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = "user@user.pl",
                    PhoneNumber = "444555666",
                    User = new User()
                    {
                        Name = "ImieU",
                        Surname = "NazwiskoU",
                        Adress = "KatowiceU",
                        PostCode = "42-501",
                    }
                };

                userManager.Create(user, "password");
            }
        }
    }
}