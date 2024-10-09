using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ProfessionalInformationConfiguration : IEntityTypeConfiguration<ProfessionalInformation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalInformation> builder)
        {
            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedade Id gerada automaticamente
            builder.Property(p => p.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            // Propriedade CompleteName (nome completo)
            builder.Property(p => p.CompleteName)
                   .IsRequired()
                   .HasMaxLength(255);

            // Propriedade Telefone
            builder.Property(p => p.Telefone)
                   .IsRequired()
                   .HasMaxLength(16);

            // Propriedade Email
            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            // Propriedade Linkedin
            builder.Property(p => p.Linkedin)
                   .HasMaxLength(255);

            // Propriedade EnderecoCompleto
            builder.Property(p => p.EnderecoCompleto)
                   .HasMaxLength(510);

            // Propriedade Objetivo
            builder.Property(p => p.Objetivo)
                   .HasMaxLength(255);

            // Propriedade ImgUrl
            builder.Property(p => p.ImgUrl)
                   .HasMaxLength(555);
        }
    }
}
