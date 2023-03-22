﻿using System.Reflection;
using Innogotchi.Application;
using Innogotchi.Application.Common.Mappings;
using Innogotchi.Application.Interfaces;
using Innogotchi.Domain;
using Innogotchi.Persistence;
using Innogotchi.WebApi.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using saja.Extensions;
using saja.Interfaces;
using Swashbuckle.AspNetCore.Filters;

namespace Innogotchi.WebApi.Extensions;

public static class ServiceMiddlewareExtension
{
    public static WebApplicationBuilder RegisterServiceMiddlewares(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        builder.Services
            .AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = InnogotchiAuthOptions.GetSymmetricSecurityKeyStatic()
                };
            });

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IInnoUserRepository).Assembly));
        });

        builder.Services
            .AddApplication()
            .AddPersistence(builder.Configuration);

        builder.Services.AddCors(options =>
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            }));
        
        return builder;
    }
    
    public static WebApplication InitializeServiceContextProvider(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var innogotchiDbContext = serviceProvider.GetRequiredService<InnogotchiDbContext>();
            DbInitializer.Initialize(innogotchiDbContext);
        }
        catch (Exception ex)
        {
            //
        }

        return app;
    }
}