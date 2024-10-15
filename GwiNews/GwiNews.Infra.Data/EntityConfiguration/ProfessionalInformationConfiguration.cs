using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ProfessionalInformationConfiguration : IEntityTypeConfiguration<ProfessionalInformation>
    {
        public void Configure(EntityTypeBuilder<ProfessionalInformation> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.CompleteName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(16);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.Linkedin)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.CompleteAddress)
                   .IsRequired()
                   .HasMaxLength(510);

            builder.Property(p => p.Purpose)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.ImgUrl)
                   .IsRequired()
                   .HasMaxLength(555);

            builder.HasOne(p => p.ReaderUser)
                   .WithMany(r => r.ProfessionalInformations)
                   .HasForeignKey(p => p.ReaderUser.Id)
                   .IsRequired();
        }
    }
}
