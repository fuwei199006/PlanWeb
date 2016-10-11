   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_PowerMap : EntityTypeConfiguration<Basic_Power>
	{
        public Basic_PowerMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.PoweName).HasMaxLength(50);
			
			this.ToTable("Basic_Power");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.PoweName).HasColumnName("PoweName"); 
			this.Property(t => t.PowerStatus).HasColumnName("PowerStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
