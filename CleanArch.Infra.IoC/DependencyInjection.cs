using CleanArch.Application.Interfaces;
using CleanArch.Application.Mappings;
using CleanArch.Application.Services;
using CleanArch.Domain.Account;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Identity;
using CleanArch.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
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
        //REGISTRANDO IDENTITY
        services.AddIdentity<ApplicationUser,IdentityRole>().
            AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(opt => opt.AccessDeniedPath = "/Account/Login");

        //RESISTRO DE REPOSITORIES
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        //RESISTRO DE SERVICES
        services.AddScoped<IProductService,ProductService>();
        services.AddScoped<ICategoryService,CategoryService>();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        return services;
    }
}
