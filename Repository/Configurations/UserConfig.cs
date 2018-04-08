using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Entities.Classes;

namespace Repository.Configurations
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.ToTable("Users");
            this.HasKey(u => u.Id);
            this.Property(u => u.Id).HasColumnName("id");
            this.Property(u => u.Name).HasColumnName("name");
            this.Property(u => u.Account).HasColumnName("account");
            this.Property(u => u.Password).HasColumnName("password");
            this.Property(u => u.Available).HasColumnName("available");
        }
    }
}
