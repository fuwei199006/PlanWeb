using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_PowerMenuMap : EntityTypeConfiguration<Basic_PowerMenu>
    {
        public Basic_PowerMenuMap()
        {
            HasKey(t => t.Id);
            ToTable("Basic_PowerMenu");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.PowerId).HasColumnName("PowerId");
            Property(t => t.MenuId).HasColumnName("MenuId");
            Property(t => t.MappingStatus).HasColumnName("MappingStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}