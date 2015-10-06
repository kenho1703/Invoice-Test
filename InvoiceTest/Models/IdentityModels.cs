using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InvoiceTest.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FavoriteBook { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
