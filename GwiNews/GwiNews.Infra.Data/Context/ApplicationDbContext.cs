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
        public DbSet<UserWithNews> UsersWithNews { get; set; } // Adicionado DbSet para UserWithNews
        public DbSet<News> News { get; set; } // **Mantenha apenas esta linha**
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

            // Configuração do relacionamento 1-N entre UserWithNews e News
            builder.Entity<UserWithNews>()
                .HasMany(u => u.News)            // UserWithNews tem muitas News
                //.WithOne(n => n.UserWithNews)     // Cada News pertence a um UserWithNews
                //.HasForeignKey(n => n.UserWithNewsId) // Configurando a chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Deletar as News ao deletar UserWithNews

            // Garantir que o e-mail dos usuários seja único
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
