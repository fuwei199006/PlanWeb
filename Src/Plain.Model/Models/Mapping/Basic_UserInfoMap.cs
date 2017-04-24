using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_UserInfoMap : EntityTypeConfiguration<Basic_UserInfo>
    {
        public Basic_UserInfoMap()
        {
            HasKey(t => t.Id);
            Property(t => t.LoginName).HasMaxLength(50);
            Property(t => t.NickName).HasMaxLength(50);
            Property(t => t.UserEmail).HasMaxLength(50);
            Property(t => t.UserPwd).HasMaxLength(100);
            Property(t => t.RealName).IsRequired().HasMaxLength(20);
            Property(t => t.MobilePhone).IsRequired().HasMaxLength(20);
            Property(t => t.QQ).IsRequired().HasMaxLength(15);
            Property(t => t.Weixin).IsRequired().HasMaxLength(20);
            Property(t => t.Addr).IsRequired().HasMaxLength(100);
            Property(t => t.OtherInfo).IsRequired().HasMaxLength(100);
            ToTable("Basic_UserInfo");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.LoginName).HasColumnName("LoginName");
            Property(t => t.NickName).HasColumnName("NickName");
            Property(t => t.UserEmail).HasColumnName("UserEmail");
            Property(t => t.UserPwd).HasColumnName("UserPwd");
            Property(t => t.RealName).HasColumnName("RealName");
            Property(t => t.UserStaus).HasColumnName("UserStaus");
            Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            Property(t => t.BirthDay).HasColumnName("BirthDay");
            Property(t => t.QQ).HasColumnName("QQ");
            Property(t => t.Weixin).HasColumnName("Weixin");
            Property(t => t.Addr).HasColumnName("Addr");
            Property(t => t.OtherInfo).HasColumnName("OtherInfo");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.Sex).HasColumnName("Sex");
        }
    }
}