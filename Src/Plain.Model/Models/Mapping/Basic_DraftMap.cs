using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_DraftMap : EntityTypeConfiguration<Basic_Draft>
    {
        public Basic_DraftMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Title).IsRequired().HasMaxLength(200);
            Property(t => t.Author).IsRequired().HasMaxLength(50);
            Property(t => t.Category).IsRequired().HasMaxLength(50);
            Property(t => t.Content).IsRequired();
            Property(t => t.Source).IsRequired().HasMaxLength(100);
            Property(t => t.KeyWord).IsRequired().HasMaxLength(50);
            ToTable("Basic_Draft");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Author).HasColumnName("Author");
            Property(t => t.Category).HasColumnName("Category");
            Property(t => t.Content).HasColumnName("Content");
            Property(t => t.Source).HasColumnName("Source");
            Property(t => t.KeyWord).HasColumnName("KeyWord");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTIme).HasColumnName("ModifyTIme");
        }
    }
}