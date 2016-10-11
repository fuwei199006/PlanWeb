   
using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_RegisterMap : EntityTypeConfiguration<Basic_Register>
	{
        public Basic_RegisterMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.RegisterName).HasMaxLength(50);
			this.Property(t => t.RegisterPassword).HasMaxLength(100);
			this.Property(t => t.RegisterEmail).HasMaxLength(50);
			this.Property(t => t.RegisterPhone).HasMaxLength(20);
			this.Property(t => t.RegisterDevice).HasMaxLength(500);
			this.Property(t => t.RetisterIp).HasMaxLength(10);
			
			this.ToTable("Basic_Register");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.RegisterName).HasColumnName("RegisterName"); 
			this.Property(t => t.RegisterPassword).HasColumnName("RegisterPassword"); 
			this.Property(t => t.RegisterEmail).HasColumnName("RegisterEmail"); 
			this.Property(t => t.RegisterPhone).HasColumnName("RegisterPhone"); 
			this.Property(t => t.RegisterTime).HasColumnName("RegisterTime"); 
			this.Property(t => t.Expiretime).HasColumnName("Expiretime"); 
			this.Property(t => t.RegisterStatus).HasColumnName("RegisterStatus"); 
			this.Property(t => t.RegisterDevice).HasColumnName("RegisterDevice"); 
			this.Property(t => t.RetisterIp).HasColumnName("RetisterIp"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.RegisterToken).HasColumnName("RegisterToken"); 
			
          
        }
    }
}
