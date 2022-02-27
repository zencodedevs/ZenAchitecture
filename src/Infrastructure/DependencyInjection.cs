﻿
using ZenAchitecture.Domain.Entities;
using ZenAchitecture.Domain.Interfaces;
using ZenAchitecture.Infrastructure.Identity;
using ZenAchitecture.Infrastructure.Persistence;
using ZenAchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zen.Bog.Ecommerce;
using Zen.EventProcessor;
using Zen.Infrastructure;
using Zen.Infrastructure.Interfaces;
using Zen.MultiTenancy;

namespace ZenAchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ZenAchitecture"));
            }
            else
            {

                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }


            services.AddZenEventProcessor();
            services.AddZenBogEcommerce(configuration);

            services.AddScoped<IAppDbContext>(provider => provider.GetService<ApplicationDbContext>());



            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var issuerUri = configuration.GetSection("EndPoints")["WebsiteURL"];

            services.AddIdentityServer(option =>
            {
                option.IssuerUri = issuerUri;
            })
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(option =>
            {
                foreach (var client in option.Clients)
                {
                    client.AllowOfflineAccess = true;
                    client.UpdateAccessTokenClaimsOnRefresh = true;
                    client.AccessTokenLifetime = 3600; // seconds / 1 hour
                }
            })
            .AddProfileService<ProfileService>();


            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.Configure<JwtBearerOptions>(
                        IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
                        options =>
                        {
                            options.Authority = issuerUri;
                        });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));


            });

            return services;
        }



    }
}