using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_PowerMap : EntityTypeConfiguration<Basic_Power>
    {
        public Basic_PowerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PoweName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_Power");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PoweName).HasColumnName("PoweName");
            this.Property(t => t.PowerStatus).HasColumnName("PowerStatus");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
