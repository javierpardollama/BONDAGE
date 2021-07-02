using System;
using System.Collections.Generic;

using AutoMapper;

using Bondage.Tier.Contexts.Classes;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Mappings.Classes;
using Bondage.Tier.Settings.Classes;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Bondage.Tier.Services.Tests.Classes
{
    /// <summary>
    /// Represents a <see cref="TestBaseService"/> class.
    /// </summary>
    public abstract class TestBaseService
    {
        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        public IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="IOptions{JwtSettings}"/>
        /// </summary>
        protected IOptions<JwtSettings> JwtOptions;

        /// <summary>
        /// Instance of <see cref="DbContextOptions{ApplicationContext}"/>
        /// </summary>
        protected DbContextOptions<ApplicationContext> ContextOptions;

        /// <summary>
        /// Instance of <see cref="ApplicationContext"/>
        /// </summary>
        public ApplicationContext Context;

        /// <summary>
        /// Instance of <see cref="UserManager{ApplicationUser}"/>
        /// </summary>
        public UserManager<ApplicationUser> UserManager;

        /// <summary>
        /// Instance of <see cref="SignInManager{ApplicationUser}"/>
        /// </summary>
        public SignInManager<ApplicationUser> SignInManager;

        /// <summary>
        /// Instance of <see cref="ServiceCollection"/>
        /// </summary>
        private ServiceCollection Services;

        /// <summary>
        /// Instance of <see cref="ServiceProvider"/>
        /// </summary>
        private ServiceProvider ServiceProvider;

        /// <summary>
        /// Sets Up Services
        /// </summary>
        public void SetUpServices()
        {
            Services = new ServiceCollection();

            Services               
                .AddDbContext<ApplicationContext>(o => o.UseSqlite("Data Source=bondage.db"))
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
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

            Services.AddLogging();

            ServiceProvider = Services.BuildServiceProvider();

            Context = new ApplicationContext(ContextOptions);
            UserManager = ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            SignInManager = ServiceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
        }

        /// <summary>
        /// Sets Up Mapper
        /// </summary>
        public void SetUpMapper()
        {
            MapperConfiguration @config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelingProfile());
            });

            Mapper = @config.CreateMapper();
        }     

        /// <summary>
        /// Sets Up Jwt Options
        /// </summary>
        public void SetUpJwtOptions() => JwtOptions = Options.Create(new JwtSettings()
        {
            JwtAudience = "http://localhost:4200",
            JwtExpireDays = 30,
            JwtIssuer = "http://localhost:15208",
            JwtKey = "SOME_RANDOM_KEY_DO_NOT_SHARE"
        });

        /// <summary>
        /// Sets Up Context Options
        /// </summary>
        public void SetUpContextOptions() => ContextOptions = new DbContextOptionsBuilder<ApplicationContext>()
           .UseInMemoryDatabase(databaseName: "Data Source=bondage.db")
           .Options;
    }
}