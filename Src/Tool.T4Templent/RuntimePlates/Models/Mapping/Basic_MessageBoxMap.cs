   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_MessageBoxMap : EntityTypeConfiguration<Basic_MessageBox>
	{
        public Basic_MessageBoxMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Title).HasMaxLength(200);
			this.Property(t => t.Content).HasMaxLength(4000);
			this.Property(t => t.ToUserName).IsRequired().HasMaxLength(50);
			this.Property(t => t.FromUserName).IsRequired().HasMaxLength(50);
			
			this.ToTable("Basic_MessageBox");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.Title).HasColumnName("Title"); 
			this.Property(t => t.Content).HasColumnName("Content"); 
			this.Property(t => t.MessageStatus).HasColumnName("MessageStatus"); 
			this.Property(t => t.ToUserId).HasColumnName("ToUserId"); 
			this.Property(t => t.ToUserName).HasColumnName("ToUserName"); 
			this.Property(t => t.FromUserId).HasColumnName("FromUserId"); 
			this.Property(t => t.FromUserName).HasColumnName("FromUserName"); 
			this.Property(t => t.SentTime).HasColumnName("SentTime"); 
			
          
        }
    }
}
