using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    public class EndeavourService : BaseService, IEndeavourService
    {
        public EndeavourService(
            IMapper mapper,
            ILogger<EndeavourService> logger) : base(mapper, logger)
        {
        }

        public async Task<ICollection<ViewEndeavour>> FindAllEndeavour()
        {
            ICollection<Endeavour> endeavours = await Context.Endeavour
                           .TagWith("FindAllEndeavour")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.ApplicationUser)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEndeavour>>(endeavours);
        }

        public async Task<ICollection<ViewEndeavour>> FindAllEndeavourByApplicationUserById(int id)
        {
            ICollection<Endeavour> endeavours = await Context.Endeavour
                           .TagWith("FindAllEndeavourByApplicationUserById")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.ApplicationUser)
                           .Where(x => x.ApplicationUser.Id == id)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEndeavour>>(endeavours);
        }

        public async Task<ApplicationUser> FindApplicationUserById(int id)
        {
            ApplicationUser applicationUser = await Context.ApplicationUser
               .TagWith("FindApplicationUserById")
               .AsQueryable()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (applicationUser == null)
            {
                // Log
                string logData = applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(applicationUser.GetType().Name
                    + " with Email "
                    + applicationUser.Email
                    + " does not exist");
            }

            return applicationUser;
        }

        public async Task<ViewEndeavour> Start(AddEndeavour viewModel)
        {
            Endeavour endeavour = new Endeavour
            {
                Start = DateTime.Now,
                ApplicationUser = await FindApplicationUserById(viewModel.ApplicationUserId)
            };

            try
            {
                await Context.Endeavour.AddAsync(endeavour);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = endeavour.GetType().Name
                + " with Id "
                + endeavour.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewEndeavour>(endeavour);
        }

        public async Task<ViewEndeavour> Finish(UpdateEndeavour viewModel)
        {
            Endeavour endeavour = await FindEndeavourById(viewModel.Id);
            endeavour.Finish = DateTime.Now;
            endeavour.ApplicationUser = await FindApplicationUserById(viewModel.ApplicationUserId);

            try
            {
                Context.Endeavour.Update(endeavour);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = endeavour.GetType().Name
                + " with Id "
                + endeavour.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewEndeavour>(endeavour);
        }

        public async Task RemoveEndeavourById(int id)
        {
            try
            {
                Endeavour endeavour = await FindEndeavourById(id);

                Context.Endeavour.Remove(endeavour);

                await Context.SaveChangesAsync();

                // Log
                string logData = endeavour.GetType().Name
                    + " with Id "
                    + endeavour.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindEndeavourById(id);
            }
        }

        public async Task<Endeavour> FindEndeavourById(int id)
        {
            Endeavour endeavour = await Context.Endeavour
                .TagWith("FindEndeavourById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (endeavour == null)
            {
                // Log
                string logData = endeavour.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(endeavour.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return endeavour;
        }
    }
}
