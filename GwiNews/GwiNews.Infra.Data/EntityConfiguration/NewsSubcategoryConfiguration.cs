using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class NewsSubcategoryConfiguration : IEntityTypeConfiguration<NewsSubcategory>
    {
        public void Configure(EntityTypeBuilder<NewsSubcategory> builder)
        {
            builder.HasKey(ns => ns.Id);

            builder.Property(ns => ns.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(ns => ns.Name)
                   .IsRequired()
                   .HasMaxLength(55);

            builder.HasOne(ns => ns.NewsCategory)
                   .WithMany(nc => nc.NewsSubcategories)
                   .HasForeignKey(ns => ns.NewsCategory.Id)
                   .IsRequired();

            builder.HasMany(ns => ns.News)
                   .WithMany(n => n.NewsSubcategories)
                   .UsingEntity<Dictionary<string, object>>(
                        "NewsSubcategoryNews",
                        j => j.HasOne<News>()
                              .WithMany()
                              .HasForeignKey("NewsId")
                              .HasConstraintName("FK_NewsSubcategoryNews_News"),
                        j => j.HasOne<NewsSubcategory>()
                              .WithMany()
                              .HasForeignKey("NewsSubcategoryId")
                              .HasConstraintName("FK_NewsSubcategoryNews_NewsSubcategory"),
                        j =>
                        {
                            j.HasKey("NewsId", "NewsSubcategoryId");
                        }
                   );
        }
    }
}
