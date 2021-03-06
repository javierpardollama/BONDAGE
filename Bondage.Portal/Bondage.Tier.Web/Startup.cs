using System;

using AutoMapper;

using Bondage.Tier.Contexts.Classes;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Mappings.Classes;
using Bondage.Tier.Settings.Classes;
using Bondage.Tier.Web.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bondage.Tier.Web
{
    /// <summary>
    /// Represents a <see cref="Startup"/> class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new Instance of<see cref="Startup"/>
        /// </summary>
        /// <param name="configuration">Injected <see cref="IConfiguration"/></param>
        public Startup(IConfiguration @configuration) => Configuration = @configuration;

        /// <summary>
        /// Gets <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or Sets <see cref="MapperConfiguration"/>
        /// </summary>
        public MapperConfiguration MapperConfiguration { get; private set; }

        /// <summary>
        /// Gets or Sets <see cref="JwtSettings"/>
        /// </summary>
        public IMapper Mapper { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="JwtSettings"/>
        /// </summary>
        public JwtSettings JwtSettings { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures Services
        /// </summary>
        /// <param name="services">Injected <see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection @services)
        {
            @services.AddControllers();

            @services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            @services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Lockout = new LockoutOptions()
                {
                    AllowedForNewUsers = true,
                    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                    MaxFailedAccessAttempts = 5
                };
            })
              .AddEntityFrameworkStores<ApplicationContext>()
              .AddDefaultTokenProviders();

            MapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelingProfile());
            });

            Mapper = MapperConfiguration.CreateMapper();

            // Add customized Mapping to the services container.
            @services.AddSingleton(Mapper);

            // Register the service and implementation for the database context
            @services.AddCustomizedContexts();

            // Add customized Entity Framework services to the services container.
            @services.AddCustomizedServices();

            // Register the Jwt Settings to the configuration container.
            JwtSettings = new JwtSettings();
            Configuration.GetSection("Jwt").Bind(JwtSettings);
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            // Add customized Authentication to the services container.
            @services.AddCustomizedAuthentication(JwtSettings);

            // Add customized Cross Origin Requests to the services container.
            @services.AddCustomizedCrossOriginRequests(JwtSettings);

            @services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            // In production, the Angular files will be served from this directory
            @services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures
        /// </summary>
        /// <param name="app">Injected <see cref="IApplicationBuilder"/></param>
        /// <param name="env">Injected <see cref="IWebHostEnvironment"/></param>
        public void Configure(IApplicationBuilder @app, IWebHostEnvironment @env)
        {
            if (@env.IsDevelopment())
            {
                @app.UseDeveloperExceptionPage();
                @app.UseCustomizedExceptionMiddlewares();
            }
            else
            {
                @app.UseCustomizedExceptionMiddlewares();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                @app.UseHsts();
            }

            @app.UseAuthentication();

            @app.UseCors("Authentication");

            @app.UseHttpsRedirection();
            @app.UseStaticFiles();
            @app.UseSpaStaticFiles();

            @app.UseRouting();

            @app.UseAuthorization();

            @app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            @app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (@env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
