using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class SalaryMap : EntityTypeConfiguration<Salary>
    {
        public SalaryMap()
        {
            HasKey(t => t.Id);
            Property(t => t.SalaryDate).IsRequired().HasMaxLength(10);
            Property(t => t.SalaryKey).IsRequired().HasMaxLength(20);
            Property(t => t.SalaryDesc).IsRequired().HasMaxLength(40);
            Property(t => t.SalaryStaff).IsRequired().HasMaxLength(20);
            ToTable("Salary");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.SalaryDate).HasColumnName("SalaryDate");
            Property(t => t.SalaryKey).HasColumnName("SalaryKey");
            Property(t => t.SalaryDesc).HasColumnName("SalaryDesc");
            Property(t => t.SalaryAccout).HasColumnName("SalaryAccout");
            Property(t => t.SalaryStaff).HasColumnName("SalaryStaff");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}