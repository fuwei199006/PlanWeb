using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_DbMonitorLogMap : EntityTypeConfiguration<Basic_DbMonitorLog>
    {
        public Basic_DbMonitorLogMap()
        {
            HasKey(t => t.Id);
            Property(t => t.ModuleId).IsRequired().HasMaxLength(20);
            Property(t => t.TableName).HasMaxLength(100);
            Property(t => t.DbName).HasMaxLength(40);
            Property(t => t.EventType).HasMaxLength(20);
            Property(t => t.NewValues).IsRequired();
            Property(t => t.UserName).IsRequired().HasMaxLength(100);
            Property(t => t.ModuleName).IsRequired().HasMaxLength(50);
            ToTable("Basic_DbMonitorLog");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ModuleId).HasColumnName("ModuleId");
            Property(t => t.TableName).HasColumnName("TableName");
            Property(t => t.DbName).HasColumnName("DbName");
            Property(t => t.EventType).HasColumnName("EventType");
            Property(t => t.NewValues).HasColumnName("NewValues");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.ModuleName).HasColumnName("ModuleName");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}