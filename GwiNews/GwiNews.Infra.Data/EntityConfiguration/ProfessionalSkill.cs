using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ProfessionalSkillConfiguration : IEntityTypeConfiguration<ProfessionalSkill>
    {
        public void Configure(EntityTypeBuilder<ProfessionalSkill> builder)
        {
            // Chave primária
            builder.HasKey(ps => ps.Id);

            // Propriedade Id gerada automaticamente
            builder.Property(ps => ps.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            // Propriedade Skill1 (habilidade 1)
            builder.Property(ps => ps.Skill1)
                   .IsRequired()
                   .HasMaxLength(55);

            // Propriedade Skill2 (habilidade 2)
            builder.Property(ps => ps.Skill2)
                   .HasMaxLength(55);

            // Propriedade Skill3 (habilidade 3)
            builder.Property(ps => ps.Skill3)
                   .HasMaxLength(55);

            // Propriedade Skill4 (habilidade 4)
            builder.Property(ps => ps.Skill4)
                   .HasMaxLength(55);
        }
    }
}
