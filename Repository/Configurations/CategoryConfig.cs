using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Repository.Configurations
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            this.ToTable("Categories");
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasColumnName("id");
            this.Property(c => c.CategoryName).HasColumnName("categoryName");
            this.Property(c => c.Available).HasColumnName("available");
            this.HasMany(c => c.Products).WithRequired(c => c.Category).HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(true);
        }
    }
}
