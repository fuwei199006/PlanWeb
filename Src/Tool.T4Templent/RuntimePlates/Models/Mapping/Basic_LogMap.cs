   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_LogMap : EntityTypeConfiguration<Basic_Log>
	{
        public Basic_LogMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Level).IsRequired().HasMaxLength(50);
			this.Property(t => t.Logger).IsRequired().HasMaxLength(255);
			this.Property(t => t.Host).IsRequired().HasMaxLength(50);
			this.Property(t => t.Thread).IsRequired().HasMaxLength(255);
			this.Property(t => t.Message).IsRequired()
			this.Property(t => t.Exception).IsRequired()
			
			this.ToTable("Basic_Log");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.Level).HasColumnName("Level"); 
			this.Property(t => t.Logger).HasColumnName("Logger"); 
			this.Property(t => t.Host).HasColumnName("Host"); 
			this.Property(t => t.Date).HasColumnName("Date"); 
			this.Property(t => t.Thread).HasColumnName("Thread"); 
			this.Property(t => t.Message).HasColumnName("Message"); 
			this.Property(t => t.Exception).HasColumnName("Exception"); 
			
          
        }
    }
}
