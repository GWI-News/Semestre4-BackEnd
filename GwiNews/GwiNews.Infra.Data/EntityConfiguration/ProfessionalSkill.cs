using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ProfessionalSkillConfiguration : IEntityTypeConfiguration<ProfessionalSkill>
    {
        public void Configure(EntityTypeBuilder<ProfessionalSkill> builder)
        {
            builder.HasKey(ps => ps.Id);

            builder.Property(ps => ps.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(ps => ps.Skill1)
                   .IsRequired()
                   .HasMaxLength(55);

            builder.Property(ps => ps.Skill2)
                   .IsRequired()
                   .HasMaxLength(55);

            builder.Property(ps => ps.Skill3)
                   .IsRequired()
                   .HasMaxLength(55);

            builder.Property(ps => ps.Skill4)
                   .IsRequired()
                   .HasMaxLength(55);

            builder.HasOne(ps => ps.ReaderUser)
                   .WithMany(r => r.ProfessionalSkills)
                   .HasForeignKey(ps => ps.ReaderUser.Id)
                   .IsRequired();
        }
    }
}
