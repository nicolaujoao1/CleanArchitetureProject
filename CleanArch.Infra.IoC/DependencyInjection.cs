using CleanArch.Application.Interfaces;
using CleanArch.Application.Mappings;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArch.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
            );
        //RESISTRO DE REPOSITORIES
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        //RESISTRO DE SERVICES
        services.AddScoped<IProductService,ProductService>();
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        return services;
    }
}
