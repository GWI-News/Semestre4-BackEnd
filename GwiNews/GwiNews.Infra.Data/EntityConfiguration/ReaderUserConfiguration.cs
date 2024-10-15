using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GwiNews.Infra.Data.EntityConfiguration
{
    public class ReaderUserConfiguration : IEntityTypeConfiguration<ReaderUser>
    {
        public void Configure(EntityTypeBuilder<ReaderUser> builder)
        {
            builder.HasBaseType<User>();

            builder.HasMany(r => r.FavoritedNews)
                   .WithMany(n => n.FavoritedBy)
                   .UsingEntity<Dictionary<string, object>>(
                        "ReaderUserNews",
                        j => j.HasOne<News>().WithMany().HasForeignKey("NewsId"),
                        j => j.HasOne<ReaderUser>().WithMany().HasForeignKey("ReaderUserId")
                    );

            builder.HasMany(r => r.ProfessionalInformations)
                   .WithOne(pi => pi.ReaderUser)
                   .HasForeignKey(pi => pi.ReaderUser.Id);

            builder.HasMany(r => r.ProfessionalSkills)
                   .WithOne(ps => ps.ReaderUser)
                   .HasForeignKey(ps => ps.ReaderUser.Id);

            builder.HasMany(r => r.Formations)
                   .WithOne(f => f.ReaderUser)
                   .HasForeignKey(f => f.ReaderUser.Id);
        }
    }
}
