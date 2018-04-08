using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Repository.Configurations
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            this.ToTable("Products");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("id");
            this.Property(p => p.ProductName).HasColumnName("productName");
            this.Property(p => p.ProductCode).HasColumnName("productCode");
            this.Property(p => p.Description).HasColumnName("description");
            this.Property(p => p.Price).HasColumnName("price");
            this.Property(p => p.ImagePath).HasColumnName("imagePath");
            this.Property(p => p.CategoryId).HasColumnName("categoryId");
            this.Property(p => p.Available).HasColumnName("available");
        }
    }
}
