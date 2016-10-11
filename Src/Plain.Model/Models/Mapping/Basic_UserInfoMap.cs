   
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
namespace Plain.Model.Models.Mapping
{
	public class Basic_UserInfoMap : EntityTypeConfiguration<Basic_UserInfo>
	{
        public Basic_UserInfoMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.LoginName)
			.HasMaxLength(50);
			this.Property(t => t.NickName)
			.HasMaxLength(50);
			this.Property(t => t.UserEmail)
			.HasMaxLength(50);
			this.Property(t => t.UserPwd)
			.HasMaxLength(100);
			this.Property(t => t.RealName)
			.IsRequired().HasMaxLength(20);
			this.Property(t => t.RegisterDevice)
			.IsRequired().HasMaxLength(500);
			this.Property(t => t.RegisterIp)
			.IsRequired().HasMaxLength(10);
			this.Property(t => t.RegiserHeader)
			.IsRequired().HasMaxLength(200);
			
			this.ToTable("Basic_UserInfo");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.LoginName).HasColumnName("LoginName"); 
			this.Property(t => t.NickName).HasColumnName("NickName"); 
			this.Property(t => t.UserEmail).HasColumnName("UserEmail"); 
			this.Property(t => t.UserPwd).HasColumnName("UserPwd"); 
			this.Property(t => t.RealName).HasColumnName("RealName"); 
			this.Property(t => t.RegisterDevice).HasColumnName("RegisterDevice"); 
			this.Property(t => t.RegisterIp).HasColumnName("RegisterIp"); 
			this.Property(t => t.RegiserHeader).HasColumnName("RegiserHeader"); 
			this.Property(t => t.RegisterTime).HasColumnName("RegisterTime"); 
			this.Property(t => t.UserStaus).HasColumnName("UserStaus"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			
          
        }
    }
}
