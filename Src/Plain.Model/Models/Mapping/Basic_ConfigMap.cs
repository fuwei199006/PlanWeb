using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_ConfigMap : EntityTypeConfiguration<Basic_Config>
    {
        public Basic_ConfigMap()
        {
            HasKey(t => t.Id);
            Property(t => t.ConfigKey).IsRequired().HasMaxLength(20);
            Property(t => t.ConfigValue).IsRequired().HasMaxLength(4000);
            Property(t => t.ConfigCategory).IsRequired().HasMaxLength(50);
            Property(t => t.ConfigDesc).IsRequired().HasMaxLength(200);
            Property(t => t.ConfigDateTag).IsRequired().HasMaxLength(50);
            Property(t => t.ConfigItemType).IsRequired().HasMaxLength(20);
            ToTable("Basic_Config");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ConfigKey).HasColumnName("ConfigKey");
            Property(t => t.ConfigValue).HasColumnName("ConfigValue");
            Property(t => t.CongfigStatus).HasColumnName("CongfigStatus");
            Property(t => t.ConfigCategory).HasColumnName("ConfigCategory");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.ConfigDesc).HasColumnName("ConfigDesc");
            Property(t => t.ConfigDateTag).HasColumnName("ConfigDateTag");
            Property(t => t.ConfigItemType).HasColumnName("ConfigItemType");
        }
    }
}