using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.Role)
                   .IsRequired();

            builder.Property(u => u.CompleteName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.Status)
                   .IsRequired();

            builder.HasIndex(u => u.Email)
                   .IsUnique();
        }
    }
}
