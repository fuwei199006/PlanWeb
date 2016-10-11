   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Basic_UserRoleMap : EntityTypeConfiguration<Basic_UserRole>
	{
        public Basic_UserRoleMap()
        {
			this.HasKey(t => t.Id);
			
			this.ToTable("Basic_UserRole");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.UserId).HasColumnName("UserId"); 
			this.Property(t => t.RoleId).HasColumnName("RoleId"); 
			this.Property(t => t.MappingStatus).HasColumnName("MappingStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
