   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class LogMap : EntityTypeConfiguration<Log>
	{
        public LogMap()
        {
			this.Property(t => t.Thread)
			.HasMaxLength(127);
			this.Property(t => t.Level)
			.HasMaxLength(25);
			this.Property(t => t.Logger)
			.HasMaxLength(127);
			this.Property(t => t.Message)
			.HasMaxLength(2000);
			this.Property(t => t.Exception)
			.IsRequired().HasMaxLength(1000);
			
			this.ToTable("Log");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.Date).HasColumnName("Date"); 
			this.Property(t => t.Thread).HasColumnName("Thread"); 
			this.Property(t => t.Level).HasColumnName("Level"); 
			this.Property(t => t.Logger).HasColumnName("Logger"); 
			this.Property(t => t.Message).HasColumnName("Message"); 
			this.Property(t => t.Exception).HasColumnName("Exception"); 
			
          
        }
    }
}
