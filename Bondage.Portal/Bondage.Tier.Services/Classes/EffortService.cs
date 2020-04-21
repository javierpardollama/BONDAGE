using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Constants.Enums;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    public class EffortService : BaseService, IEffortService
    {
        public EffortService(
            IMapper mapper,
            ILogger<EffortService> logger) : base(mapper, logger)
        {
        }

        public async Task<ICollection<ViewEffort>> FindAllEffort()
        {
            ICollection<Effort> efforts = await Context.Effort
                           .TagWith("FindAllEffort")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.Breaks)
                           .Include(x => x.ApplicationUser)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEffort>>(efforts);
        }

        public async Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserById(int id)
        {
            ICollection<Effort> efforts = await Context.Effort
                           .TagWith("FindAllEffortByApplicationUserById")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.Breaks)
                           .Include(x => x.ApplicationUser)
                           .Where(x => x.ApplicationUser.Id == id)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEffort>>(efforts);
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

        public async Task<ViewEffort> Start(AddEffort viewModel)
        {
            Effort effort = new Effort
            {
                ApplicationUser = await FindApplicationUserById(viewModel.ApplicationUserId),
            };

            try
            {
                await Context.Effort.AddAsync(effort);

                await AddStartBreak(effort);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = effort.GetType().Name
                + " with Id "
                + effort.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewEffort>(effort);
        }

        public async Task<ViewEffort> Pause(AddBreak viewModel)
        {
            Effort effort = await FindEffortById(viewModel.EffortId);

            try
            {
                await AddPauseBreak(effort);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = effort.GetType().Name
                + " with Id "
                + effort.Id
                + " was updated at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewEffort>(effort);
        }

        public async Task<ViewEffort> Resume(AddBreak viewModel)
        {
            Effort effort = await FindEffortById(viewModel.EffortId);

            try
            {
                await AddResumeBreak(effort);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = effort.GetType().Name
                + " with Id "
                + effort.Id
                + " was updated at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewEffort>(effort);
        }

        public async Task<ViewEffort> Stop(AddBreak viewModel)
        {
            Effort effort = await FindEffortById(viewModel.EffortId);

            try
            {
                await AddStopBreak(effort);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            // Log
            string logData = effort.GetType().Name
                + " with Id "
                + effort.Id
                + " was updated at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewEffort>(effort);
        }

        public async Task AddStartBreak(Effort entity) => Context.Break.Add(
            new Break
            {
                Date = DateTime.Now,
                Effort = entity,
                Kind = await FindKindById((int)EffortKinds.Start)
            });

        public async Task AddPauseBreak(Effort entity) => Context.Break.Add(
            new Break
            {
                Date = DateTime.Now,
                Effort = entity,
                Kind = await FindKindById((int)EffortKinds.Pause)
            });

        public async Task AddResumeBreak(Effort entity) => Context.Break.Add(
            new Break
            {
                Date = DateTime.Now,
                Effort = entity,
                Kind = await FindKindById((int)EffortKinds.Resume)
            });

        public async Task AddStopBreak(Effort entity) => Context.Break.Add(
             new Break
             {
                 Date = DateTime.Now,
                 Effort = entity,
                 Kind = await FindKindById((int)EffortKinds.Stop)
             });

        public async Task RemoveEffortById(int id)
        {
            try
            {
                Effort effort = await FindEffortById(id);

                Context.Effort.Remove(effort);

                await Context.SaveChangesAsync();

                // Log
                string logData = effort.GetType().Name
                    + " with Id "
                    + effort.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindEffortById(id);
            }
        }

        public async Task<Effort> FindEffortById(int id)
        {
            Effort effort = await Context.Effort
                .TagWith("FindEffortById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (effort == null)
            {
                // Log
                string logData = effort.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(effort.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return effort;
        }

        public async Task<Kind> FindKindById(int id)
        {
            Kind kind = await Context.Kind
                .TagWith("FindKindById")
                .FirstOrDefaultAsync(x => x.Id == id);

            if (kind == null)
            {
                // Log
                string logData = kind.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(kind.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return kind;
        }

    }
}
