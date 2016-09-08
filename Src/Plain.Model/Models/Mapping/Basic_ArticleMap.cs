using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models;

namespace Plain.Model.Models.Mapping
{
    public class Basic_ArticleMap : EntityTypeConfiguration<Basic_Article>
    {
        public Basic_ArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.SubTitle)
               .IsRequired()
               .HasMaxLength(200);
            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Content)
                .IsRequired();

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.KeyWord)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_Article");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.SubTitle).HasColumnName("SubTitle");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.KeyWord).HasColumnName("KeyWord");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTIme).HasColumnName("ModifyTIme");
            this.Property(t => t.ArticleStatus).HasColumnName("ArticleStatus");
        }
    }
}
