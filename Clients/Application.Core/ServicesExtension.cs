using Application.Core.Interfaces.Services;
using Application.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Application.Core
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddHttpClient<IApiService, ApiService>("api");

            return services;
        }
    }
}
