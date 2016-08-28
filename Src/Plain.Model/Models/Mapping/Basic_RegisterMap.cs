using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_RegisterMap : EntityTypeConfiguration<Basic_Register>
    {
        public Basic_RegisterMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RegisterName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RegisterDevice)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.RetisterIp)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Basic_Register");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegisterName).HasColumnName("RegisterName");
            this.Property(t => t.RegisterTime).HasColumnName("RegisterTime");
            this.Property(t => t.Expiretime).HasColumnName("Expiretime");
            this.Property(t => t.RegisterStatus).HasColumnName("RegisterStatus");
            this.Property(t => t.RegisterDevice).HasColumnName("RegisterDevice");
            this.Property(t => t.RetisterIp).HasColumnName("RetisterIp");
        }
    }
}
