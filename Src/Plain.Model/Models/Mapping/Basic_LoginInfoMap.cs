   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Basic_LoginInfoMap : EntityTypeConfiguration<Basic_LoginInfo>
	{
        public Basic_LoginInfoMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.LoginName)
			.IsRequired().HasMaxLength(50);
			this.Property(t => t.LoginIp)
			.IsRequired().HasMaxLength(10);
			this.Property(t => t.LoginHeader)
			 .HasMaxLength(100);
			
			this.ToTable("Basic_LoginInfo");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.LoginUserId).HasColumnName("LoginUserId");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.LoginNickName).HasColumnName("LoginNickName"); 
			this.Property(t => t.LoginTime).HasColumnName("LoginTime"); 
			this.Property(t => t.LoginStatus).HasColumnName("LoginStatus"); 
			this.Property(t => t.LoginType).HasColumnName("LoginType"); 
			this.Property(t => t.ExpireTime).HasColumnName("ExpireTime"); 
			this.Property(t => t.LoginIp).HasColumnName("LoginIp"); 
			this.Property(t => t.LoginHeader).HasColumnName("LoginHeader"); 
			this.Property(t => t.IsDelete).HasColumnName("IsDelete"); 
			this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime"); 
			this.Property(t => t.LoginToken).HasColumnName("LoginToken"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			
          
        }
    }
}
