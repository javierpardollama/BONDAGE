using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.Settings.Classes;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    public class BaseService : IBaseService
    {
        protected readonly IApplicationContext Context;

        protected readonly IMapper Mapper;

        protected readonly ILogger Logger;

        protected readonly IConfiguration Configuration;

        protected readonly JwtSettings JwtSettings;

        protected readonly IcoSettings IcoSettings;

        public BaseService(IApplicationContext context,
                           IMapper mapper,
                           ILogger logger)
        {
            Context = context;
            Mapper = mapper;
            Logger = logger;
        }

        public BaseService(IMapper mapper,
                           ILogger logger)
        {
            Mapper = mapper;
            Logger = logger;
        }

        public BaseService(
            IConfiguration configuration
           )
        {
            Configuration = configuration;

            JwtSettings = new JwtSettings();
            Configuration.GetSection("Jwt").Bind(JwtSettings);

            IcoSettings = new IcoSettings();
            Configuration.GetSection("Ico").Bind(JwtSettings);
        }
    }
}
