   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_PowerRoleMap : EntityTypeConfiguration<Basic_PowerRole>
	{
        public Basic_PowerRoleMap()
        {
			this.HasKey(t => t.Id);
			
			this.ToTable("Basic_PowerRole");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.RoleId).HasColumnName("RoleId"); 
			this.Property(t => t.PowerId).HasColumnName("PowerId"); 
			this.Property(t => t.MappingStatus).HasColumnName("MappingStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
