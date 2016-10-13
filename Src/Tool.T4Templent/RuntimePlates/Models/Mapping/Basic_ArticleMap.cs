   using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_ArticleMap : EntityTypeConfiguration<Basic_Article>
	{
        public Basic_ArticleMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Title).HasMaxLength(200);
			this.Property(t => t.SubTitle).IsRequired().HasMaxLength(200);
			this.Property(t => t.Author).HasMaxLength(50);
			this.Property(t => t.Category).HasMaxLength(50);
			this.Property(t => t.Content).IsRequired();
			this.Property(t => t.Source).HasMaxLength(100);
			this.Property(t => t.SourceUrl).HasMaxLength(100);
			this.Property(t => t.KeyWord).IsRequired().HasMaxLength(50);
						this.ToTable("Basic_Article");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.Title).HasColumnName("Title"); 
			this.Property(t => t.SubTitle).HasColumnName("SubTitle"); 
			this.Property(t => t.Author).HasColumnName("Author"); 
			this.Property(t => t.Category).HasColumnName("Category"); 
			this.Property(t => t.Content).HasColumnName("Content"); 
			this.Property(t => t.Source).HasColumnName("Source"); 
			this.Property(t => t.SourceUrl).HasColumnName("SourceUrl"); 
			this.Property(t => t.Sort).HasColumnName("Sort"); 
			this.Property(t => t.KeyWord).HasColumnName("KeyWord"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTIme).HasColumnName("ModifyTIme"); 
			this.Property(t => t.ArticleStatus).HasColumnName("ArticleStatus"); 
			          
        }
    }
}
