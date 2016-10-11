   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Log4netMap : EntityTypeConfiguration<Log4net>
	{
        public Log4netMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Level)
			.IsRequired().HasMaxLength(50);
			this.Property(t => t.Logger)
			.IsRequired().HasMaxLength(255);
			this.Property(t => t.Host)
			.IsRequired().HasMaxLength(50);
			this.Property(t => t.Thread)
			.IsRequired().HasMaxLength(255);
            this.Property(t => t.Message)
            .IsRequired();

            this.Property(t => t.Exception)
            .IsRequired();
			
			this.ToTable("Log4net");
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
