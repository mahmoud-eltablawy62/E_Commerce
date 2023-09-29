using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata;


namespace ECommerce.Models
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
        .HasOne(e => e.Cart)
        .WithOne(a => a.customer)
        .HasForeignKey<Cart>(a => a.customer_id);

            modelBuilder.Entity<Category>()
               .HasMany(c => c.products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.Cat_id)
               .OnDelete(DeleteBehavior.Cascade);
        }

       
    }
}




