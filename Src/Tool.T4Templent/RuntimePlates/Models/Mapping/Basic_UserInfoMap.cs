   using System.Data.Entity.ModelConfiguration;
using  Plain.Model.Models.Model.Models.Model;
namespace  Plain.Model.Models.Model.Models.Mapping
{
	public class Basic_UserInfoMap : EntityTypeConfiguration<Basic_UserInfo>
	{
        public Basic_UserInfoMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.LoginName).HasMaxLength(50);
			this.Property(t => t.NickName).HasMaxLength(50);
			this.Property(t => t.UserEmail).HasMaxLength(50);
			this.Property(t => t.UserPwd).HasMaxLength(100);
			this.Property(t => t.RealName).IsRequired().HasMaxLength(20);
			this.Property(t => t.MobilePhone).IsRequired().HasMaxLength(20);
			this.Property(t => t.QQ).IsRequired().HasMaxLength(15);
			this.Property(t => t.Weixin).IsRequired().HasMaxLength(20);
			this.Property(t => t.Addr).IsRequired().HasMaxLength(100);
			this.Property(t => t.OtherInfo).IsRequired().HasMaxLength(100);
						this.ToTable("Basic_UserInfo");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.LoginName).HasColumnName("LoginName"); 
			this.Property(t => t.NickName).HasColumnName("NickName"); 
			this.Property(t => t.UserEmail).HasColumnName("UserEmail"); 
			this.Property(t => t.UserPwd).HasColumnName("UserPwd"); 
			this.Property(t => t.RealName).HasColumnName("RealName"); 
			this.Property(t => t.UserStaus).HasColumnName("UserStaus"); 
			this.Property(t => t.MobilePhone).HasColumnName("MobilePhone"); 
			this.Property(t => t.BirthDay).HasColumnName("BirthDay"); 
			this.Property(t => t.QQ).HasColumnName("QQ"); 
			this.Property(t => t.Weixin).HasColumnName("Weixin"); 
			this.Property(t => t.Addr).HasColumnName("Addr"); 
			this.Property(t => t.OtherInfo).HasColumnName("OtherInfo"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			this.Property(t => t.Sex).HasColumnName("Sex"); 
			          
        }
    }
}
