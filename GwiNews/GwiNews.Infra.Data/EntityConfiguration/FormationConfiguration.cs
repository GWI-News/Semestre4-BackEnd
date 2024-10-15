using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class FormationConfiguration : IEntityTypeConfiguration<Formation>
    {
        public void Configure(EntityTypeBuilder<Formation> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(f => f.Institution)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(f => f.StartDate)
                   .IsRequired();

            builder.Property(f => f.EndDate)
                   .IsRequired();

            builder.Property(f => f.Activity1)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(f => f.Activity2)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(f => f.Activity3)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(f => f.ReaderUser)
                   .WithMany(r => r.Formations)
                   .HasForeignKey(f => f.ReaderUser.Id)
                   .IsRequired();
        }
    }
}
