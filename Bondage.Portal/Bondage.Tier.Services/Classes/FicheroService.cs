using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    public class FicheroService : BaseService, IFicheroService
    {
        private readonly UserManager<ApplicationUser> UserManager;

        public FicheroService(UserManager<ApplicationUser> userManager,
                              IApplicationContext context,
                              IMapper mapper,
                              ILogger<FicheroService> logger) : base(context, mapper, logger)
        {
            UserManager = userManager;
        }

        public async Task<Fichero> FindFicheroById(int id)
        {
            Fichero fichero = await Context.Fichero
                 .TagWith("FindFicheroById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (fichero == null)
            {
                // Log
                string logData = fichero.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(fichero.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return fichero;
        }

        public async Task RemoveFicheroById(int id)
        {
            Fichero fichero = await FindFicheroById(id);

            Context.Fichero.Remove(fichero);

            await Context.SaveChangesAsync();

            // Log
            string logData = fichero.GetType().Name
                + " with Id "
                + fichero.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<IList<ViewFichero>> FindAllFichero()
        {
            ICollection<Fichero> ficheros = await Context.Fichero
                .TagWith("FindAllFichero")
                .AsQueryable()
                .Include(x => x.Parent)
                .Include(x => x.By)
                .ToListAsync();

            return Mapper.Map<IList<ViewFichero>>(ficheros);
        }

        public async Task<IList<ViewFichero>> FindAllFicheroByApplicationUserId(int id)
        {
            ICollection<Fichero> ficheros = await Context.Fichero
               .TagWith("FindAllFicheroByApplicationUserId")
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.Parent)
                .Include(x => x.By)
               .Where(x => x.By.Id == id)
               .ToListAsync();

            return Mapper.Map<IList<ViewFichero>>(ficheros);
        }

        public async Task<ApplicationUser> FindApplicationUserByEmail(string email)
        {
            ApplicationUser applicationUser = await UserManager.Users
                .TagWith("FindApplicationUserByEmail")
                .AsQueryable()
                .Include(x => x.ApplicationUserTokens)
                .Include(x => x.ApplicationUserRoles)
                .ThenInclude(x => x.ApplicationRole)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (applicationUser == null)
            {
                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(applicationUser.GetType().Name
                    + " with Email "
                    + email
                    + " does not exist");
            }

            return applicationUser;
        }
    }
}
