using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_LoginInfoMap : EntityTypeConfiguration<Basic_LoginInfo>
    {
        public Basic_LoginInfoMap()
        {
            HasKey(t => t.Id);
            Property(t => t.LoginNickName).IsRequired().HasMaxLength(50);
            Property(t => t.LoginName).IsRequired().HasMaxLength(50);
            Property(t => t.LoginIp).IsRequired().HasMaxLength(10);
            Property(t => t.LoginHeader).IsRequired().HasMaxLength(100);
            ToTable("Basic_LoginInfo");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.LoginUserId).HasColumnName("LoginUserId");
            Property(t => t.LoginNickName).HasColumnName("LoginNickName");
            Property(t => t.LoginName).HasColumnName("LoginName");
            Property(t => t.LoginTime).HasColumnName("LoginTime");
            Property(t => t.LoginStatus).HasColumnName("LoginStatus");
            Property(t => t.LoginType).HasColumnName("LoginType");
            Property(t => t.ExpireTime).HasColumnName("ExpireTime");
            Property(t => t.LoginIp).HasColumnName("LoginIp");
            Property(t => t.LoginHeader).HasColumnName("LoginHeader");
            Property(t => t.IsDelete).HasColumnName("IsDelete");
            Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            Property(t => t.LoginToken).HasColumnName("LoginToken");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
        }
    }
}