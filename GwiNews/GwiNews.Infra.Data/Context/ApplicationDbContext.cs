using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<ReaderUser> ReaderUsers { get; set; }
        public DbSet<UserWithNews> UsersWithNews { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<ProfessionalInformation> ProfessionalInformations { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<ProfessionalSkill> ProfessionalSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
