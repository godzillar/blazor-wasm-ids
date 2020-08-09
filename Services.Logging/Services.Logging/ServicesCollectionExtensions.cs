using Microsoft.Extensions.DependencyInjection;
using Services.Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Logging
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.AddScoped<ILogService>
        }
    }
}
