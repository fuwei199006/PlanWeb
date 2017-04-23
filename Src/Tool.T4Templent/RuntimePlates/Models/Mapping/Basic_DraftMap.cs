   using System.Data.Entity.ModelConfiguration;
using  Plain.Model.Models.Model.Models.Model;
namespace  Plain.Model.Models.Model.Models.Mapping
{
	public class Basic_DraftMap : EntityTypeConfiguration<Basic_Draft>
	{
        public Basic_DraftMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.Title).IsRequired().HasMaxLength(200);
			this.Property(t => t.Author).IsRequired().HasMaxLength(50);
			this.Property(t => t.Category).IsRequired().HasMaxLength(50);
			this.Property(t => t.Content).IsRequired();
			this.Property(t => t.Source).IsRequired().HasMaxLength(100);
			this.Property(t => t.KeyWord).IsRequired().HasMaxLength(50);
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
