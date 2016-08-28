using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Plain.Model.Models.Mapping
{
    public class Basic_MessageBoxMap : EntityTypeConfiguration<Basic_MessageBox>
    {
        public Basic_MessageBoxMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.ToUserName)
                .HasMaxLength(50);

            this.Property(t => t.FromUserName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Basic_MessageBox");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.MessageStatus).HasColumnName("MessageStatus");
            this.Property(t => t.ToUserId).HasColumnName("ToUserId");
            this.Property(t => t.ToUserName).HasColumnName("ToUserName");
            this.Property(t => t.FromUserId).HasColumnName("FromUserId");
            this.Property(t => t.FromUserName).HasColumnName("FromUserName");
            this.Property(t => t.SentTime).HasColumnName("SentTime");
        }
    }
}
