using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MainDataMap : EntityTypeConfiguration<Basic_MainData>
    {
        public Basic_MainDataMap()
        {
            HasKey(t => t.Id);
            Property(t => t.MainKey).HasMaxLength(20);
            Property(t => t.MainCode).HasMaxLength(20);
            Property(t => t.MainData).HasMaxLength(100);
            ToTable("Basic_MainData");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.MainKey).HasColumnName("MainKey");
            Property(t => t.MainCode).HasColumnName("MainCode");
            Property(t => t.MainData).HasColumnName("MainData");
            Property(t => t.MainStatus).HasColumnName("MainStatus");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}