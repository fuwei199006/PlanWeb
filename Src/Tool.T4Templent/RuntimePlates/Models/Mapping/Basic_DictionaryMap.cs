   using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basic_DictionaryMap : EntityTypeConfiguration<Basic_Dictionary>
	{
        public Basic_DictionaryMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.FieldName).HasMaxLength(50);
			this.Property(t => t.FieldRemark).HasMaxLength(50);
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
