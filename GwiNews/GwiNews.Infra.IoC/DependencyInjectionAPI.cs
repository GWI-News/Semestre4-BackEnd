using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GwiNews.Application.Interfaces;
using GwiNews.Application.Mappings;
using GwiNews.Application.Services;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using GwiNews.Infra.Data.Repositories;
using GwiNews.Application.CQRS.UsersCQRS.Handlers;
using GwiNews.Application.CQRS.CategoriesCQRS.Handlers;
using GwiNews.Application.CQRS.NewsCQRS.Handlers;
using GwiNews.Application.CQRS.UserWithNewsCQRS.Handlers;

namespace GwiNews.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IFormationRepository, FormationRepository>();
            services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsSubcategoryRepository, NewsSubcategoryRepository>();
            services.AddScoped<IProfessionalInformationRepository, ProfessionalInformationRepository>();
            services.AddScoped<IProfessionalSkillRepository, ProfessionalSkillRepository>();
            services.AddScoped<IReaderUserRepository, ReaderUserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserWithNewsRepository, UserWithNewsRepository>();

            services.AddScoped<INewsCategoryService, NewsCategoryService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserWithNewsService, UserWithNewsService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("GwiNews.Application");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(UserCreateCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(NewsCategoryCreateCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(NewsCreateCommandHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UserWithNewsCreateCommandHandler).Assembly);
            });

            return services;
        }
    }
}
