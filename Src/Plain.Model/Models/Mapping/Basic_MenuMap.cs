using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MenuMap : EntityTypeConfiguration<Basic_Menu>
    {
        public Basic_MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MenuName)
                .HasMaxLength(50);

            this.Property(t => t.MenuUrl)
                .HasMaxLength(100);

            this.Property(t => t.MenuType)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Basic_Menu");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MenuName).HasColumnName("MenuName");
            this.Property(t => t.MenuUrl).HasColumnName("MenuUrl");
            this.Property(t => t.MenuType).HasColumnName("MenuType");
            this.Property(t => t.MenuSort).HasColumnName("MenuSort");
            this.Property(t => t.MenuParentId).HasColumnName("MenuParentId");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
