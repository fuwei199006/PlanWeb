   using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_TaskMap : EntityTypeConfiguration<Basic_Task>
	{
        public Basic_TaskMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.TaskName).HasMaxLength(20);
			this.Property(t => t.ReturnMsg).IsRequired().HasMaxLength(200);
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
