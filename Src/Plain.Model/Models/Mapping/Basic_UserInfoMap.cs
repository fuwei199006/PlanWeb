using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_UserInfoMap : EntityTypeConfiguration<Basic_UserInfo>
    {
        public Basic_UserInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LoginName)
                .IsRequired()
                .HasMaxLength(50);
            // Properties
            this.Property(t => t.NickName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserEmail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserPwd)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.RealName)
                .HasMaxLength(20);

            this.Property(t => t.RegisterDevice)
                .HasMaxLength(500);

            this.Property(t => t.RegisterIp)
                .HasMaxLength(10);

            this.Property(t => t.RegiserHeader)
                .HasMaxLength(200);

            // Table & Column Mappings
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
