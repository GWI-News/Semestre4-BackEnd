using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(nc => nc.Id);

            builder.Property(nc => nc.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(nc => nc.Name)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.HasMany(nc => nc.News)
                   .WithOne(n => n.NewsCategory)
                   .HasForeignKey(n => n.NewsCategory.Id);

            builder.HasMany(nc => nc.NewsSubcategories)
                   .WithOne(ns => ns.NewsCategory)
                   .HasForeignKey(ns => ns.NewsCategory.Id);
        }
    }
}
