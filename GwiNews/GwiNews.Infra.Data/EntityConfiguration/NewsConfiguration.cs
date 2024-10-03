using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntityConfiguration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                .ValueGeneratedOnAdd();

            builder.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(n => n.Subtitle)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(n => n.NewsBody)
                .IsRequired()
                .HasMaxLength(65535);

            builder.Property(n => n.NewsUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(n => n.ImageUrl)
                .HasMaxLength(555)
                .IsRequired(false);

            builder.Property(n => n.PublicationDate)
                .IsRequired();

            builder.Property(n => n.Status)
                .IsRequired()
                .HasConversion<int>();

            
            /* builder.HasMany(n => n.Authors)
                .WithOne(y => y.News)
                .HasForeignKey(z => z.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(n => n.Editors)
                .WithOne(y => y.News)
                .HasForeignKey(z => z.EditorId)
                .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(n => n.NewsSubcategories)
                .WithMany(y => y.News);

                builder.HasMany(n => n.FavoritedByUsers)
                .WithMany(y => y.FavoritedNews); */
            
        }
    }
}

