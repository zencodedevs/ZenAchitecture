﻿using Askmethat.Aspnet.JsonLocalizer.Localizer;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using SendGrid.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using Zen.Application;
using ZenAchitecture.Application.Shared.Localization;
using ZenAchitecture.Domain.Shared.Common;

namespace Application.Shared
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationShared(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());

            //zen application
            services.AddZenApplication();

            services.AddLocalization(o =>
            {
                // We will put our translations in a folder called Resources
                o.ResourcesPath = "Resources";
            });
            services.TryAddTransient<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.TryAddTransient<IStringLocalizer, JsonStringLocalizer>();
            CultureInfo.CurrentCulture = new CultureInfo(Constants.SystemCultureNames.Georgian);
           
            //zen send grid
            services.AddSendGrid(options => { options.ApiKey = configuration["SendGrid:ApiKey"]; });

            return services;
        }
    }
}
