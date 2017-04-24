using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_RegisterMap : EntityTypeConfiguration<Basic_Register>
    {
        public Basic_RegisterMap()
        {
            HasKey(t => t.Id);
            Property(t => t.RegisterName).HasMaxLength(50);
            Property(t => t.RegisterPassword).HasMaxLength(100);
            Property(t => t.RegisterEmail).HasMaxLength(50);
            Property(t => t.RegisterPhone).HasMaxLength(20);
            Property(t => t.RegisterDevice).HasMaxLength(500);
            Property(t => t.RetisterIp).HasMaxLength(10);
            ToTable("Basic_Register");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.RegisterName).HasColumnName("RegisterName");
            Property(t => t.RegisterPassword).HasColumnName("RegisterPassword");
            Property(t => t.RegisterEmail).HasColumnName("RegisterEmail");
            Property(t => t.RegisterPhone).HasColumnName("RegisterPhone");
            Property(t => t.RegisterTime).HasColumnName("RegisterTime");
            Property(t => t.Expiretime).HasColumnName("Expiretime");
            Property(t => t.RegisterStatus).HasColumnName("RegisterStatus");
            Property(t => t.RegisterDevice).HasColumnName("RegisterDevice");
            Property(t => t.RetisterIp).HasColumnName("RetisterIp");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.RegisterToken).HasColumnName("RegisterToken");
        }
    }
}