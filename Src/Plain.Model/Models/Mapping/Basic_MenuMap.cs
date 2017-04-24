using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MenuMap : EntityTypeConfiguration<Basic_Menu>
    {
        public Basic_MenuMap()
        {
            HasKey(t => t.Id);
            Property(t => t.MenuName).IsRequired().HasMaxLength(50);
            Property(t => t.MenuUrl).IsRequired().HasMaxLength(100);
            Property(t => t.MenuType).IsRequired().HasMaxLength(10);
            Property(t => t.MenuIcon).IsRequired().HasMaxLength(20);
            ToTable("Basic_Menu");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.MenuName).HasColumnName("MenuName");
            Property(t => t.MenuUrl).HasColumnName("MenuUrl");
            Property(t => t.MenuType).HasColumnName("MenuType");
            Property(t => t.MenuSort).HasColumnName("MenuSort");
            Property(t => t.MenuParentId).HasColumnName("MenuParentId");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.MenuStatus).HasColumnName("MenuStatus");
            Property(t => t.MenuIcon).HasColumnName("MenuIcon");
        }
    }
}