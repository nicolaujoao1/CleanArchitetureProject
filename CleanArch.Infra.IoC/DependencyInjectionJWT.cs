using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CleanArch.Infra.IoC
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfraestructureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
           ).AddJwtBearer(opt =>
           {
               opt.TokenValidationParameters = new TokenValidationParameters { 
                 ValidateIssuer = true,
                 ValidateAudience = true,   
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                   //VALORES VALIDOS
                   ValidIssuer = configuration["Jwt:Issuer"],
                   ValidAudience = configuration["Jwt:Audience"],
                   IssuerSigningKey=new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                   ClockSkew=TimeSpan.Zero
               };
           });
            return services;
        }
    }
}
