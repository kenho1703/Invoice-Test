using System.Collections.Generic;
using InvoiceTest.Models;

namespace InvoiceTest.Migrations
{
    using InvoiceTest.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "InvoiceTest.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "sallen"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "sallen" };

                manager.Create(user, "password");
            }
            var products = new List<Product>
            {
                new Product { Name = "iPhone 5 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "iPad mini with Wi-Fi 32GB - White & Silver",   Price = 740}, 
                new Product { Name = "iPhone 6 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "iPhone 5S 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "iPhone 6S 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "Nokia Lumina 720",   Price = 740}, 
                new Product { Name = "Galaxy Note 5",   Price = 740}, 
                new Product { Name = "iPhone 4 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "iPhone 6 Plus 32GB White & Silver (GSM) Unlocked",   Price = 740}, 
                new Product { Name = "Nokia 1280",   Price = 740},
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
