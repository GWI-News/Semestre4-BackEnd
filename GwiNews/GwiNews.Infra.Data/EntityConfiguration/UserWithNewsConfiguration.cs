using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class UserWithNewsConfiguration : IEntityTypeConfiguration<UserWithNews>
    {
        public void Configure(EntityTypeBuilder<UserWithNews> builder)
        {
          
            builder.ToTable("UserWithNews");

          
            builder.HasKey(u => u.Id);

            
            builder.Property(u => u.CompleteName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            
            builder.HasMany(u => u.News)
                .WithOne() 
                .HasForeignKey(n => n.UserId); 
        }
    }
}
