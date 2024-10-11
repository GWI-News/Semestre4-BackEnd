using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(n => n.Name)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.HasMany(n => n.News)
                   .WithOne(news => news.NewsCategory)
                   .HasForeignKey(news => news.NewsCategoryId);

            /*builder.HasMany(nc => nc.NewsSubcategories)
                   .WithOne(subcategory => subcategory.NewsCategory)
                   .HasForeignKey(subcategory => subcategory.NewsCategory.Id);*/
        }
    }
}
