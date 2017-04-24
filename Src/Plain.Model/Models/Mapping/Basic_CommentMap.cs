using System.Data.Entity.ModelConfiguration;
using Tool.T4Templent.RuntimePlates.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_CommentMap : EntityTypeConfiguration<Basic_Comment>
    {
        public Basic_CommentMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Content).HasMaxLength(2000);
            Property(t => t.CommitUserName).HasMaxLength(100);
            ToTable("Basic_Comment");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Content).HasColumnName("Content");
            Property(t => t.CommitUserName).HasColumnName("CommitUserName");
            Property(t => t.CommitUserId).HasColumnName("CommitUserId");
            Property(t => t.CommitType).HasColumnName("CommitType");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.ModifyTime).HasColumnName("ModifyTime");
        }
    }
}