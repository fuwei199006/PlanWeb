using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_RoleMap : EntityTypeConfiguration<Basic_Role>
    {
        public Basic_RoleMap()
        {
            HasKey(t => t.Id);
            Property(t => t.RoleName).IsRequired().HasMaxLength(50);
            Property(t => t.RoleGroup).IsRequired().HasMaxLength(10);
            ToTable("Basic_Role");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.RoleName).HasColumnName("RoleName");
            Property(t => t.RoleStatus).HasColumnName("RoleStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.RoleGroup).HasColumnName("RoleGroup");
        }
    }
}