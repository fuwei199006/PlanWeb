﻿   using System.Data.Entity.ModelConfiguration;
using  Plain.Model.Models.Model.Models.Model;
namespace  Plain.Model.Models.Model.Models.Mapping
{
	public class Basic_MenuMap : EntityTypeConfiguration<Basic_Menu>
	{
        public Basic_MenuMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.MenuName).IsRequired().HasMaxLength(50);
			this.Property(t => t.MenuUrl).IsRequired().HasMaxLength(100);
			this.Property(t => t.MenuType).IsRequired().HasMaxLength(10);
			this.Property(t => t.MenuIcon).IsRequired().HasMaxLength(20);
						this.ToTable("Basic_Menu");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.MenuName).HasColumnName("MenuName"); 
			this.Property(t => t.MenuUrl).HasColumnName("MenuUrl"); 
			this.Property(t => t.MenuType).HasColumnName("MenuType"); 
			this.Property(t => t.MenuSort).HasColumnName("MenuSort"); 
			this.Property(t => t.MenuParentId).HasColumnName("MenuParentId"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			this.Property(t => t.MenuStatus).HasColumnName("MenuStatus"); 
			this.Property(t => t.MenuIcon).HasColumnName("MenuIcon"); 
			          
        }
    }
}
