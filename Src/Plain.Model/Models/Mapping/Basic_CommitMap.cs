   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Basic_CommitMap : EntityTypeConfiguration<Basic_Commit>
	{
        public Basic_CommitMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Content)
			.HasMaxLength(2000);
			this.Property(t => t.CommitUserName)
			.HasMaxLength(100);
			
			this.ToTable("Basic_Commit");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.Content).HasColumnName("Content"); 
			this.Property(t => t.CommitUserName).HasColumnName("CommitUserName"); 
			this.Property(t => t.CommitUserId).HasColumnName("CommitUserId"); 
			this.Property(t => t.CommitType).HasColumnName("CommitType"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			
          
        }
    }
}
