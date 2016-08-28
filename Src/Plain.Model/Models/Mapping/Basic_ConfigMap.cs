using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models;

namespace Plain.Model.Models.Mapping
{
    public class Basic_ConfigMap : EntityTypeConfiguration<Basic_Config>
    {
        public Basic_ConfigMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ConfigKey)
                .HasMaxLength(20);

            this.Property(t => t.ConfigValue)
                .HasMaxLength(2000);

            this.Property(t => t.ConfigCategory)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_Config");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ConfigKey).HasColumnName("ConfigKey");
            this.Property(t => t.ConfigValue).HasColumnName("ConfigValue");
            this.Property(t => t.CongfigStatus).HasColumnName("CongfigStatus");
            this.Property(t => t.ConfigCategory).HasColumnName("ConfigCategory");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
