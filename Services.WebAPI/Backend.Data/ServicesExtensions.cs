using Backend.Data.DataContext;
using Backend.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Backend.Data
{
    public enum DatabaseType
    {
        /// <summary>
        /// Use an microsoft sql server database.
        /// </summary>
        SqlServer,

        /// <summary>
        /// Use an sqlite database.
        /// </summary>
        SqLite
    }

    public static class ServicesExtensions
    {
        public static IServiceCollection AddBackendDataLayer(this IServiceCollection services, DatabaseType dataType, string databaseConnectionString)
        {
            switch(dataType)
            {
                case DatabaseType.SqlServer:
                    services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(databaseConnectionString));
                    break;
                case DatabaseType.SqLite:
                    services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlite(databaseConnectionString));
                    break;
                default:
                    throw new InvalidEnumArgumentException("Could not find database type in options");

            }

            return services;
        }
    }
}
