using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Backend.Api.Configuration;
using Backend.Core.Settings;
using Backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = CreateLogger();
        }

        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        public IConfigurationRoot Configuration { get; private set; }

        /// <summary>
        /// Gets the autofac container used for dependency injection.
        /// </summary>
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // This api is authenticated using Bearer tokens as created by id server running on localhost:5000 with scope api1.
            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options =>
            {
                options.Authority = "https://localhost:5001";
                options.RequireHttpsMetadata = false;

                options.ApiName = "api1";
            });

            // For now set CORS to accept all from origin localhost:7001
            services.AddCors(options=>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("https://localhost:7001").AllowAnyHeader().AllowAnyMethod();
                });
            });

            var databaseSettings = Configuration.GetSection("Database").Get<DatabaseSettings>(c=>c.BindNonPublicProperties = true);

            if(databaseSettings == null)
            {
                throw new ApplicationException("The configuration file does not container database section.");
            }

            // Enable logging
            services.AddLogging(loggingBuilder=>loggingBuilder.AddSerilog(dispose:true));

            services.AddBackendDataLayer(DatabaseType.SqlServer, databaseSettings.ConnectionString);

            services.AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacDependencyInjectionConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => { options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod(); });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private Serilog.ILogger CreateLogger()
        {
            return new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
        }
    }
}
