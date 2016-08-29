using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models;

namespace Plain.Model.Models.Mapping
{
    public class Basic_LoginInfoMap : EntityTypeConfiguration<Basic_LoginInfo>
    {
        public Basic_LoginInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.LoginName)
                .HasMaxLength(50);

            this.Property(t => t.LoginIp)
                .HasMaxLength(10);

            this.Property(t => t.LoginHeader)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Basic_LoginInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.LoginUserId).HasColumnName("LoginUserId");
            this.Property(t => t.LogStatus).HasColumnName("LogStatus");
            this.Property(t => t.LogType).HasColumnName("LogType");
            this.Property(t => t.LoginName).HasColumnName("LoginName");
            this.Property(t => t.LoginTime).HasColumnName("LoginTime");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ExpireTime).HasColumnName("ExpireTime");
            this.Property(t => t.LoginIp).HasColumnName("LoginIp");
            this.Property(t => t.LoginHeader).HasColumnName("LoginHeader");
            this.Property(t => t.IsDelete).HasColumnName("IsDelete");
            this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
        }
    }
}
