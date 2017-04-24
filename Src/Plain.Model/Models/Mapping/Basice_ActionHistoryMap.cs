using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basice_ActionHistoryMap : EntityTypeConfiguration<Basice_ActionHistory>
    {
        public Basice_ActionHistoryMap()
        {
            HasKey(t => t.Id);
            Property(t => t.ActionType).HasMaxLength(50);
            Property(t => t.ActionName).HasMaxLength(50);
            Property(t => t.ActionExcutorId).HasMaxLength(50);
            Property(t => t.ActionExcutorName).HasMaxLength(50);
            Property(t => t.ActionExcutorRole).HasMaxLength(50);
            Property(t => t.ActionBackPack).IsRequired();
            Property(t => t.ActionResult).IsRequired();
            ToTable("Basice_ActionHistory");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.ActionType).HasColumnName("ActionType");
            Property(t => t.ActionName).HasColumnName("ActionName");
            Property(t => t.ActionExcutorId).HasColumnName("ActionExcutorId");
            Property(t => t.ActionExcutorName).HasColumnName("ActionExcutorName");
            Property(t => t.ActionExcutorRole).HasColumnName("ActionExcutorRole");
            Property(t => t.ActionBackPack).HasColumnName("ActionBackPack");
            Property(t => t.ActionResult).HasColumnName("ActionResult");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}