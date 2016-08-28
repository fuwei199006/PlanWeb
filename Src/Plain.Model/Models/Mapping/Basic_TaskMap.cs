using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_TaskMap : EntityTypeConfiguration<Basic_Task>
    {
        public Basic_TaskMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TaskName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ReturnMsg)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Basic_Task");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TaskName).HasColumnName("TaskName");
            this.Property(t => t.StarTime).HasColumnName("StarTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.TaskStatus).HasColumnName("TaskStatus");
            this.Property(t => t.ExecTime).HasColumnName("ExecTime");
            this.Property(t => t.ExecEndTime).HasColumnName("ExecEndTime");
            this.Property(t => t.ReturnMsg).HasColumnName("ReturnMsg");
        }
    }
}
