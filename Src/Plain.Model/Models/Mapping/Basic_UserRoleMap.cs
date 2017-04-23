using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_UserRoleMap : EntityTypeConfiguration<Basic_UserRole>
    {
        public Basic_UserRoleMap()
        {
            HasKey(t => t.Id);
            ToTable("Basic_UserRole");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.RoleId).HasColumnName("RoleId");
            Property(t => t.MappingStatus).HasColumnName("MappingStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}