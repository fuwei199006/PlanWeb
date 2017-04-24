using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_DictionaryMap : EntityTypeConfiguration<Basic_Dictionary>
    {
        public Basic_DictionaryMap()
        {
            HasKey(t => t.Id);
            Property(t => t.FieldName).HasMaxLength(50);
            Property(t => t.FieldRemark).HasMaxLength(50);
            Property(t => t.FieldModule).IsRequired().HasMaxLength(50);
            ToTable("Basic_Dictionary");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FieldName).HasColumnName("FieldName");
            Property(t => t.FieldRemark).HasColumnName("FieldRemark");
            Property(t => t.DicStatus).HasColumnName("DicStatus");
            Property(t => t.FieldModule).HasColumnName("FieldModule");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}