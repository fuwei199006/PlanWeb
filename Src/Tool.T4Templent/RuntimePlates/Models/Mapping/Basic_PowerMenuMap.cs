   using System.Data.Entity.ModelConfiguration;
using  Plain.Model.Models.Model.Models.Model;
namespace  Plain.Model.Models.Model.Models.Mapping
{
	public class Basic_PowerMenuMap : EntityTypeConfiguration<Basic_PowerMenu>
	{
        public Basic_PowerMenuMap()
        {
			this.HasKey(t => t.Id);
						this.ToTable("Basic_PowerMenu");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.PowerId).HasColumnName("PowerId"); 
			this.Property(t => t.MenuId).HasColumnName("MenuId"); 
			this.Property(t => t.MappingStatus).HasColumnName("MappingStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			          
        }
    }
}
