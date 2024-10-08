using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using GwiNews.Infra.Data.Repositories;
using Infra.Data.Repositories;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GwiNews.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();

            return services;
        }
    }
}
