using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
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

        public async Task<ViewFichero> AddFichero(AddFichero viewModel)
        {
            await CheckName(viewModel);

            Fichero fichero = new Fichero
            {
                Name = viewModel.Name,
                Data = viewModel.Data,
                By = await FindApplicationUserByEmail(viewModel.By.Email)
            };

            await Context.Fichero.AddAsync(fichero);

            await Context.SaveChangesAsync();

            // Log
            string logData = fichero.GetType().Name
                + " with Id "
                + fichero.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewFichero>(fichero);
        }

        public async Task<ViewFichero> UpdateFichero(UpdateFichero viewModel)
        {
            Fichero fichero = await FindFicheroById(viewModel.Id);
            fichero.Name = viewModel.Name;
            fichero.Data = viewModel.Data;
            fichero.By = await FindApplicationUserByEmail(viewModel.By.Email);

            Context.Fichero.Update(fichero);

            await Context.SaveChangesAsync();

            // Log
            string logData = fichero.GetType().Name
                + " with Id "
                + fichero.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewFichero>(fichero);
        }

        public async Task<Fichero> CheckName(AddFichero viewModel)
        {
            Fichero fichero = await Context.Fichero
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (fichero != null)
            {
                // Log
                string logData = fichero.GetType().Name
                    + " with Name "
                    + fichero.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(fichero.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return fichero;
        }

    }
}
