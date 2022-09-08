using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.IoC
{
    public static class DependecyInjectionSwagger
    {
        public static IServiceCollection AddInfrastrutureSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen();
            service.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usinf the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                        "adn then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                      {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
            return service;
        }
    }
}
