   using System.Data.Entity.ModelConfiguration;
using  Plain.Model.Models.Model.Models.Model;
namespace  Plain.Model.Models.Model.Models.Mapping
{
	public class SalaryMap : EntityTypeConfiguration<Salary>
	{
        public SalaryMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.SalaryDate).IsRequired().HasMaxLength(10);
			this.Property(t => t.SalaryKey).IsRequired().HasMaxLength(20);
			this.Property(t => t.SalaryDesc).IsRequired().HasMaxLength(40);
			this.Property(t => t.SalaryStaff).IsRequired().HasMaxLength(20);
						this.ToTable("Salary");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.SalaryDate).HasColumnName("SalaryDate"); 
			this.Property(t => t.SalaryKey).HasColumnName("SalaryKey"); 
			this.Property(t => t.SalaryDesc).HasColumnName("SalaryDesc"); 
			this.Property(t => t.SalaryAccout).HasColumnName("SalaryAccout"); 
			this.Property(t => t.SalaryStaff).HasColumnName("SalaryStaff"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			          
        }
    }
}
