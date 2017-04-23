using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            Property(t => t.Thread).HasMaxLength(127);
            Property(t => t.Level).HasMaxLength(25);
            Property(t => t.Logger).HasMaxLength(127);
            Property(t => t.Message).HasMaxLength(2000);
            Property(t => t.Exception).IsRequired().HasMaxLength(1000);

            ToTable("Log");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Date).HasColumnName("Date");
            Property(t => t.Thread).HasColumnName("Thread");
            Property(t => t.Level).HasColumnName("Level");
            Property(t => t.Logger).HasColumnName("Logger");
            Property(t => t.Message).HasColumnName("Message");
            Property(t => t.Exception).HasColumnName("Exception");
        }
    }
}