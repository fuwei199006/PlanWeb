   using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_DbMonitorLogMap : EntityTypeConfiguration<Basic_DbMonitorLog>
	{
        public Basic_DbMonitorLogMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.ModuleId).IsRequired().HasMaxLength(20);
			this.Property(t => t.TableName).HasMaxLength(100);
			this.Property(t => t.DbName).HasMaxLength(40);
			this.Property(t => t.EventType).HasMaxLength(20);
			this.Property(t => t.NewValues).IsRequired();
			this.Property(t => t.UserName).IsRequired().HasMaxLength(100);
			this.Property(t => t.ModuleName).IsRequired().HasMaxLength(50);
						this.ToTable("Basic_DbMonitorLog");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.ModuleId).HasColumnName("ModuleId"); 
			this.Property(t => t.TableName).HasColumnName("TableName"); 
			this.Property(t => t.DbName).HasColumnName("DbName"); 
			this.Property(t => t.EventType).HasColumnName("EventType"); 
			this.Property(t => t.NewValues).HasColumnName("NewValues"); 
			this.Property(t => t.UserName).HasColumnName("UserName"); 
			this.Property(t => t.ModuleName).HasColumnName("ModuleName"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			          
        }
    }
}
