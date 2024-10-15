using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class UserWithNewsConfiguration : IEntityTypeConfiguration<UserWithNews>
    {
        public void Configure(EntityTypeBuilder<UserWithNews> builder)
        {
            builder.HasBaseType<User>();

            builder.HasMany(u => u.News)
            .WithOne(n => n.Editor)
            .HasForeignKey(n => n.Editor.Id);

            builder.HasMany(u => u.News)
            .WithOne(n => n.Author)
            .HasForeignKey(n => n.Author.Id);
        }
    }
}