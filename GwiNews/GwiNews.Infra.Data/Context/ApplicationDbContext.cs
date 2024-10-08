using GwiNews.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSets para todas as entidades
        public DbSet<User> Users { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<ProfessionalInformation> ProfessionalInformation { get; set; }
        public DbSet<ProfessionalSkill> ProfessionalSkills { get; set; }

        // Configurações de modelagem
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Aplica as configurações de todas as entidades do assembly atual
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Aqui você pode adicionar mais configurações personalizadas de modelagem
            // Exemplo: Configurações específicas para uma entidade
            // builder.Entity<Formation>().HasKey(f => f.Id);
        }
    }
}
