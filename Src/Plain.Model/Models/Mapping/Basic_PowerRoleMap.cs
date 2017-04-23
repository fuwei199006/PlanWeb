using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_PowerRoleMap : EntityTypeConfiguration<Basic_PowerRole>
    {
        public Basic_PowerRoleMap()
        {
            HasKey(t => t.Id);
            ToTable("Basic_PowerRole");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.RoleId).HasColumnName("RoleId");
            Property(t => t.PowerId).HasColumnName("PowerId");
            Property(t => t.MappingStatus).HasColumnName("MappingStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}