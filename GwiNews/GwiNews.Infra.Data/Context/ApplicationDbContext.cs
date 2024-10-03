using Microsoft.EntityFrameworkCore;
using GwiNews.Domain.Entities;
using EntityConfiguration;
using System.Reflection.Emit;

namespace GwiNews.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
