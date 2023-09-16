using Microsoft.EntityFrameworkCore;
using DCEwebapp.Models;

namespace DCEwebapp.Data
{
    public class DCEDbContext : DbContext
    {
        public DCEDbContext(DbContextOptions<DCEDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
