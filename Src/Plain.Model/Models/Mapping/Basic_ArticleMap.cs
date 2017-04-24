using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_ArticleMap : EntityTypeConfiguration<Basic_Article>
    {
        public Basic_ArticleMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Title).HasMaxLength(200);
            Property(t => t.SubTitle).IsRequired().HasMaxLength(500);
            Property(t => t.Author).HasMaxLength(50);
            Property(t => t.Category).HasMaxLength(50);
            Property(t => t.Content).IsRequired();
            Property(t => t.Source).HasMaxLength(100);
            Property(t => t.SourceUrl).HasMaxLength(200);
            Property(t => t.KeyWord).IsRequired().HasMaxLength(200);
            Property(t => t.Position).IsRequired().HasMaxLength(20);
            ToTable("Basic_Article");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.SubTitle).HasColumnName("SubTitle");
            Property(t => t.Author).HasColumnName("Author");
            Property(t => t.Category).HasColumnName("Category");
            Property(t => t.Content).HasColumnName("Content");
            Property(t => t.Source).HasColumnName("Source");
            Property(t => t.SourceUrl).HasColumnName("SourceUrl");
            Property(t => t.Sort).HasColumnName("Sort");
            Property(t => t.KeyWord).HasColumnName("KeyWord");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTIme).HasColumnName("ModifyTIme");
            Property(t => t.ArticleStatus).HasColumnName("ArticleStatus");
            Property(t => t.Position).HasColumnName("Position");
        }
    }
}