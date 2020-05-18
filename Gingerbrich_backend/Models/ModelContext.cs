using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gingerbrich_backend.Models;

namespace Gingerbrich_backend.Models
{
    public class ModelContext: DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Permission>().HasKey(sc => new { sc.customerId, sc.permisssionId });
            modelBuilder.Entity<Product_Discount>().HasKey(sc => new { sc.productId, sc.discountId });
            modelBuilder.Entity<Order_Product>().HasKey(sc => new { sc.OrderId, sc.ProductId });
            modelBuilder.Entity<Customer_Notification>().HasKey(sc => new { sc.customerId, sc.notificationId });
            modelBuilder.Entity<Customer>().HasIndex(c => c.Username).IsUnique();
            modelBuilder.Entity<Image>().HasIndex(c => c.Url).IsUnique();
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer_Permission> Customer_Permission { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Product_Discount> Product_Discount { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Customer_Notification> Customer_Notification { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public DbSet<Gingerbrich_backend.Models.Brand> Brand { get; set; }
    }
}
