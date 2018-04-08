using Entities.Classes;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Repository.Configurations
{
    public class OrderProductsConfig : EntityTypeConfiguration<OrderProducts>
    {
        public OrderProductsConfig()
        {
            this.ToTable("OrderDetails");
            this.HasKey(o => o.Id);
            this.Property(o => o.Id).HasColumnName("id");
            this.Property(o => o.ProductName).HasColumnName("productName");
            this.Property(o => o.ProductCode).HasColumnName("productCode");
            this.Property(o => o.Price).HasColumnName("price");
            this.Property(o => o.OrderId).HasColumnName("orderId");
        }
    }
}
