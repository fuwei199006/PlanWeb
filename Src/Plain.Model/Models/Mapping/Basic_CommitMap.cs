using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_CommitMap : EntityTypeConfiguration<Basic_Commit>
    {
        public Basic_CommitMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Content).HasMaxLength(2000);
            Property(t => t.CommitUserName).HasMaxLength(100);
            ToTable("Basic_Commit");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Content).HasColumnName("Content");
            Property(t => t.CommitUserName).HasColumnName("CommitUserName");
            Property(t => t.CommitUserId).HasColumnName("CommitUserId");
            Property(t => t.CommitType).HasColumnName("CommitType");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            Property(t => t.ArticleId).HasColumnName("ArticleId");
        }
    }
}