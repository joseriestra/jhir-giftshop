using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Configuration;
using Entities.Classes;
using Repository.Configurations;

namespace Repository.General
{
    public class GiftShopDbContext : DbContext
    {
        public GiftShopDbContext() : base(ConfigurationManager.ConnectionStrings["GiftShop"].ConnectionString) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderProducts> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OrderProductsConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
