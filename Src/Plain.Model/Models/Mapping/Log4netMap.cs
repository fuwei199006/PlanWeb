using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Log4netMap : EntityTypeConfiguration<Log4net>
    {
        public Log4netMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Level).IsRequired().HasMaxLength(50);
            Property(t => t.Logger).IsRequired().HasMaxLength(255);
            Property(t => t.Host).IsRequired().HasMaxLength(50);
            Property(t => t.Thread).IsRequired().HasMaxLength(255);
            Property(t => t.Message).IsRequired();
            Property(t => t.Exception).IsRequired();

            ToTable("Log4net");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Level).HasColumnName("Level");
            Property(t => t.Logger).HasColumnName("Logger");
            Property(t => t.Host).HasColumnName("Host");
            Property(t => t.Date).HasColumnName("Date");
            Property(t => t.Thread).HasColumnName("Thread");
            Property(t => t.Message).HasColumnName("Message");
            Property(t => t.Exception).HasColumnName("Exception");
        }
    }
}