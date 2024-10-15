using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(n => n.Status)
                   .IsRequired();

            builder.Property(n => n.NewsUrl)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(n => n.Title)
                   .IsRequired()
                   .HasMaxLength(75);

            builder.Property(n => n.Subtitle)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(n => n.NewsBody)
                   .IsRequired()
                   .HasMaxLength(65535);

            builder.Property(n => n.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(555);

            builder.Property(n => n.PublicationDate)
                   .IsRequired();

            builder.HasOne(n => n.Author)
                   .WithMany(u => u.News)
                   .HasForeignKey(n => n.Author.Id)
                   .IsRequired();

            builder.HasOne(n => n.Editor)
                   .WithMany(u => u.News)
                   .HasForeignKey(n => n.Editor.Id)
                   .IsRequired();

            builder.HasOne(n => n.NewsCategory)
                   .WithMany(nc => nc.News)
                   .HasForeignKey(n => n.NewsCategory.Id)
                   .IsRequired();

            builder.HasMany(n => n.NewsSubcategories)
                   .WithMany(ns => ns.News);

            builder.HasMany(n => n.FavoritedBy)
                   .WithMany(r => r.FavoritedNews);
        }
    }
}
