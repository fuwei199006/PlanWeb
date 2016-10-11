   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Basic_MainDataMap : EntityTypeConfiguration<Basic_MainData>
	{
        public Basic_MainDataMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.MainKey)
			.HasMaxLength(20);
			this.Property(t => t.MainCode)
			.HasMaxLength(20);
			this.Property(t => t.MainData)
			.HasMaxLength(100);
			
			this.ToTable("Basic_MainData");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.MainKey).HasColumnName("MainKey"); 
			this.Property(t => t.MainCode).HasColumnName("MainCode"); 
			this.Property(t => t.MainData).HasColumnName("MainData"); 
			this.Property(t => t.MainStatus).HasColumnName("MainStatus"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
