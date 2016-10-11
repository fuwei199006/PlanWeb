   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_RoleMap : EntityTypeConfiguration<Basic_Role>
	{
        public Basic_RoleMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.RoleName).IsRequired().HasMaxLength(50);
			
			this.ToTable("Basic_Role");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.RoleName).HasColumnName("RoleName"); 
			this.Property(t => t.RoleStatus).HasColumnName("RoleStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
