   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_ConfigMap : EntityTypeConfiguration<Basic_Config>
	{
        public Basic_ConfigMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.ConfigKey).IsRequired().HasMaxLength(20);
			this.Property(t => t.ConfigValue).IsRequired().HasMaxLength(4000);
			this.Property(t => t.ConfigCategory).IsRequired().HasMaxLength(50);
			
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
