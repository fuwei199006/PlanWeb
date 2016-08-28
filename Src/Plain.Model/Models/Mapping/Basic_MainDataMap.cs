using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MainDataMap : EntityTypeConfiguration<Basic_MainData>
    {
        public Basic_MainDataMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.MainKey)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.MainCode)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.MainData)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Basic_MainData");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MainKey).HasColumnName("MainKey");
            this.Property(t => t.MainCode).HasColumnName("MainCode");
            this.Property(t => t.MainData).HasColumnName("MainData");
            this.Property(t => t.MainStatus).HasColumnName("MainStatus");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
