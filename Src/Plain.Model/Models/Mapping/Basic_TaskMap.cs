using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_TaskMap : EntityTypeConfiguration<Basic_Task>
    {
        public Basic_TaskMap()
        {
            HasKey(t => t.Id);
            Property(t => t.TaskName).HasMaxLength(20);
            Property(t => t.ReturnMsg).IsRequired().HasMaxLength(200);
            ToTable("Basic_Task");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.TaskName).HasColumnName("TaskName");
            Property(t => t.StarTime).HasColumnName("StarTime");
            Property(t => t.EndTime).HasColumnName("EndTime");
            Property(t => t.TaskStatus).HasColumnName("TaskStatus");
            Property(t => t.ExecTime).HasColumnName("ExecTime");
            Property(t => t.ExecEndTime).HasColumnName("ExecEndTime");
            Property(t => t.ReturnMsg).HasColumnName("ReturnMsg");
        }
    }
}