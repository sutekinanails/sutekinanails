using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using suteservice.api.Controllers;
using suteservice.api.Settings;
using suteservice.domain.AggregatesModel.UserAgregate;
using suteservice.infrastructure.Repositories;

namespace suteservice.api {
    public class Startup {

        public IConfiguration Configuration { get; }
        private readonly ILogger _logger;
/* 
        public Startup (IHostingEnvironment env) {

            var builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath);

            if (env.IsDevelopment ()) {
                builder.AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional : true);
            } else {
                builder.AddJsonFile ($"appsettings.json", optional : false, reloadOnChange : true);
            }

            builder.AddEnvironmentVariables ();

            Configuration = builder.Build ();
        }*/

        public Startup (IConfiguration configuration, ILogger<Startup> logger) {
            Configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices (IServiceCollection services) {

            _logger.LogInformation("Configuring services.");

            services.AddMvc ()
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            // logging informations about the application settings.
            string connString = Configuration.GetSection ("MongoConnection:ConnectionString").Value;
            string dataBaseName = Configuration.GetSection ("MongoConnection:DatabaseName").Value;
            _logger.LogInformation($"Using configurations of data access with {connString} and database name {dataBaseName}.");

            services.Configure<AppSettings> (options => {
                options.ConnectionString = Configuration.GetSection ("MongoConnection:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection ("MongoConnection:DatabaseName").Value;
             });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UsersController>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            
            _logger.LogInformation($"Configure api in {env.EnvironmentName} environment.");
            
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseMvc(routes => {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            //var routes = new RouteBuilder(app);

        }
    }
}