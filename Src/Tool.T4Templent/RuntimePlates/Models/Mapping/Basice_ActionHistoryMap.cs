   using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;
namespace Tool.T4Templent.RuntimePlates.Models.Mapping
{
	public class Basice_ActionHistoryMap : EntityTypeConfiguration<Basice_ActionHistory>
	{
        public Basice_ActionHistoryMap()
        {
			this.HasKey(t => t.Id);
			this.Property(t => t.ActionType).HasMaxLength(50);
			this.Property(t => t.ActionName).HasMaxLength(50);
			this.Property(t => t.ActionExcutorId).HasMaxLength(50);
			this.Property(t => t.ActionExcutorName).HasMaxLength(50);
			this.Property(t => t.ActionExcutorRole).HasMaxLength(50);
			this.Property(t => t.ActionBackPack).IsRequired();
			this.Property(t => t.ActionResult).IsRequired();
						this.ToTable("Basice_ActionHistory");
			this.Property(t => t.Id).HasColumnName("Id"); 
			this.Property(t => t.ActionType).HasColumnName("ActionType"); 
			this.Property(t => t.ActionName).HasColumnName("ActionName"); 
			this.Property(t => t.ActionExcutorId).HasColumnName("ActionExcutorId"); 
			this.Property(t => t.ActionExcutorName).HasColumnName("ActionExcutorName"); 
			this.Property(t => t.ActionExcutorRole).HasColumnName("ActionExcutorRole"); 
			this.Property(t => t.ActionBackPack).HasColumnName("ActionBackPack"); 
			this.Property(t => t.ActionResult).HasColumnName("ActionResult"); 
			this.Property(t => t.CreateTime).HasColumnName("CreateTime"); 
			this.Property(t => t.ModifyTime).HasColumnName("ModifyTime"); 
			          
        }
    }
}
