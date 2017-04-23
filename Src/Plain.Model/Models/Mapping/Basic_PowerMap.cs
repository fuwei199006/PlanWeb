using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_PowerMap : EntityTypeConfiguration<Basic_Power>
    {
        public Basic_PowerMap()
        {
            HasKey(t => t.Id);
            Property(t => t.PoweName).HasMaxLength(50);
            Property(t => t.PowerGroup).IsRequired().HasMaxLength(10);
            ToTable("Basic_Power");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.PoweName).HasColumnName("PoweName");
            Property(t => t.PowerStatus).HasColumnName("PowerStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.PowerGroup).HasColumnName("PowerGroup");
        }
    }
}