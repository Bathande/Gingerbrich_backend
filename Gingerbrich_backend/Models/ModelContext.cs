﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gingerbrich_backend.Models
{
    public class ModelContext: DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Permission>().HasKey(sc => new { sc.PermissionId, sc.CustomerId });
            modelBuilder.Entity<Product_Discount>().HasKey(sc => new { sc.DiscountId, sc.ProductId });
            modelBuilder.Entity<Order_Product>().HasKey(sc => new { sc.CustomerId, sc.ProductId });
            modelBuilder.Entity<Customer_Notification>().HasKey(sc => new { sc.CustomerID, sc.NotificationID });
            modelBuilder.Entity<Customer>().HasIndex(c => c.username).IsUnique();
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
    }
}
