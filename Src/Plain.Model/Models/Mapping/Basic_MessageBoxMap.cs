using System.Data.Entity.ModelConfiguration;
using Plain.Model.Models.Model;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MessageBoxMap : EntityTypeConfiguration<Basic_MessageBox>
    {
        public Basic_MessageBoxMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Title).HasMaxLength(200);
            Property(t => t.Content).HasMaxLength(4000);
            Property(t => t.ToUserName).IsRequired().HasMaxLength(50);
            Property(t => t.FromUserName).IsRequired().HasMaxLength(50);
            ToTable("Basic_MessageBox");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Content).HasColumnName("Content");
            Property(t => t.MessageStatus).HasColumnName("MessageStatus");
            Property(t => t.ToUserId).HasColumnName("ToUserId");
            Property(t => t.ToUserName).HasColumnName("ToUserName");
            Property(t => t.FromUserId).HasColumnName("FromUserId");
            Property(t => t.FromUserName).HasColumnName("FromUserName");
            Property(t => t.SentTime).HasColumnName("SentTime");
        }
    }
}