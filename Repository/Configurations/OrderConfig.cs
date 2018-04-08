using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Repository.Configurations
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            this.ToTable("Orders");
            this.HasKey(o => o.Id);
            this.Property(o => o.Id).HasColumnName("id");
            this.Property(o => o.OrderDate).HasColumnName("orderDate");
            this.Property(o => o.ShippingAdress).HasColumnName("shippingAdress");
            this.Property(o => o.PayMentMethod).HasColumnName("paymentMethod");
            this.Property(o => o.Total).HasColumnName("total");
            this.Property(o => o.UserId).HasColumnName("userId");

            this.HasMany(o => o.Products).WithRequired(o => o.Order).HasForeignKey(o => o.OrderId).WillCascadeOnDelete(true);
        }
    }
}
