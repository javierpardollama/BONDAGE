using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.Settings.Classes;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="BaseService"/> class. Implements <see cref="IBaseService"/>
    /// </summary>
    public class BaseService : IBaseService
    {
        /// <summary>
        /// Instance of <see cref="IApplicationContext"/>
        /// </summary>
        protected readonly IApplicationContext Context;

        /// <summary>
        /// Instance of <see cref="IMapper"/>
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Instance of <see cref="ILogger"/>
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// Instance of <see cref="IConfiguration"/>
        /// </summary>
        protected readonly IConfiguration Configuration;

        /// <summary>
        /// Instance of <see cref="JwtSettings"/>
        /// </summary>
        protected readonly JwtSettings JwtSettings;

        /// <summary>
        /// Initializes a new Instance of <see cref="BaseService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public BaseService(IApplicationContext @context,
                           IMapper @mapper,
                           ILogger @logger)
        {
            Context = @context;
            Mapper = @mapper;
            Logger = @logger;
        }      

        /// <summary>
        /// Initializes a new Instance of <see cref="BaseService"/>
        /// </summary>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        /// <param name="configuration">Injected <see cref="IConfiguration"/></param>
        public BaseService(IMapper @mapper,
                           ILogger @logger,
                           IConfiguration @configuration)
        {
            Mapper = @mapper;
            Logger = @logger;
            Configuration = @configuration;
            JwtSettings = new JwtSettings();
            Configuration.GetSection("Jwt").Bind(JwtSettings);
        }

        /// <summary>
        /// Initializes a new Instance of <see cref="BaseService"/>
        /// </summary>
        /// <param name="configuration">Injected <see cref="IConfiguration"/></param>
        public BaseService(
            IConfiguration @configuration
           )
        {
            Configuration = @configuration;

            JwtSettings = new JwtSettings();
            Configuration.GetSection("Jwt").Bind(JwtSettings);
        }
    }
}