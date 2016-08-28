using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models;

namespace Plain.Model.Models.Mapping
{
    public class Basic_DraftMap : EntityTypeConfiguration<Basic_Draft>
    {
        public Basic_DraftMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.Author)
                .HasMaxLength(50);

            this.Property(t => t.Category)
                .HasMaxLength(50);

            this.Property(t => t.Source)
                .HasMaxLength(100);

            this.Property(t => t.KeyWord)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_Draft");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.KeyWord).HasColumnName("KeyWord");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTIme).HasColumnName("ModifyTIme");
        }
    }
}
