using GwiNews.Application.Interfaces;
using GwiNews.Application.Mappings;
using GwiNews.Application.Services;
using GwiNews.Application.Users.Handlers;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using GwiNews.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

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

            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserCreateQueryHandler).Assembly));

            return services;
        }
    }
}
