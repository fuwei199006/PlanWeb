using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models;

namespace Plain.Model.Models.Mapping
{
    public class Basic_DictionaryMap : EntityTypeConfiguration<Basic_Dictionary>
    {
        public Basic_DictionaryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FieldName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FieldRemark)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_Dictionary");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FieldName).HasColumnName("FieldName");
            this.Property(t => t.FieldRemark).HasColumnName("FieldRemark");
            this.Property(t => t.DicStatus).HasColumnName("DicStatus");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}
