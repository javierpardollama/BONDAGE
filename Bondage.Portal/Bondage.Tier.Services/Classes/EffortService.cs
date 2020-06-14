using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Constants.Enums;
using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="EffortService"/> class. Inherits <see cref="BaseService"/>. Implemenets <see cref="IEffortService"/>
    /// </summary>
    public class EffortService : BaseService, IEffortService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="EffortService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger{EffortService}"/></param>
        public EffortService(
            IApplicationContext @context,
            IMapper @mapper,
            ILogger<EffortService> @logger) : base(@context, @mapper, @logger)
        {
        }

        /// <summary>
        /// Finds Last Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        public async Task<ViewEffort> FindLastActiveEffortByApplicationUserId(int @id)
        {
            Effort @effort = await Context.Effort
              .AsNoTracking()
              .AsQueryable()
              .TagWith("FindLastActiveEffortByApplicationUserId")
              .Include(x => x.ApplicationUser)
              .Include(x => x.Kind)
              .Where(x => x.ApplicationUser.Id == @id)
              .Where(x => x.Active)
              .OrderByDescending(x => x.LastModified)
              .FirstOrDefaultAsync(x => x.Active);

            return Mapper.Map<ViewEffort>(@effort);
        }

        /// <summary>
        /// Finds Current Day Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> FindCurrentDayActiveEffortByApplicationUserId(int @id)
        {
            return await Context.Effort
              .AsNoTracking()
              .AsQueryable()
              .TagWith("FindCurrentEffortByApplicationUserId")
              .Include(x => x.ApplicationUser)
              .Include(x => x.Kind)
              .Where(x => x.ApplicationUser.Id == @id)
              .Where(x => x.Active)
              .OrderByDescending(x => x.LastModified)
              .FirstOrDefaultAsync(x => x.LastModified.Date == DateTime.Now.Date);
        }

        /// <summary>
        /// Finds Former Day Active Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> FindFormerDayActiveEffortByApplicationUserId(int @id)
        {
            return await Context.Effort
              .AsNoTracking()
              .AsQueryable()
              .TagWith("FindFormerDayActiveEffortByApplicationUserId")
              .Include(x => x.ApplicationUser)
              .Include(x => x.Kind)
              .Where(x => x.ApplicationUser.Id == @id)
              .Where(x => x.Active)
              .OrderByDescending(x => x.LastModified)
              .FirstOrDefaultAsync(x => x.LastModified.Date.DayOfYear == DateTime.Now.Date.DayOfYear - 1);
        }

        /// <summary>
        /// Finds All Effort
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewEffort}}"/></returns>
        public async Task<ICollection<ViewEffort>> FindAllEffort()
        {
            ICollection<Effort> @efforts = await Context.Effort
                           .TagWith("FindAllEffort")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.ApplicationUser)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEffort>>(@efforts);
        }

        /// <summary>
        /// Finds All Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ICollection{ViewEffort}}"/></returns>
        public async Task<ICollection<ViewEffort>> FindAllEffortByApplicationUserId(int @id)
        {
            ICollection<Effort> @efforts = await Context.Effort
                           .TagWith("FindAllEffortByApplicationUserId")
                           .AsQueryable()
                           .AsNoTracking()
                           .Include(x => x.ApplicationUser)
                           .Where(x => x.ApplicationUser.Id == @id)
                           .OrderByDescending(x => x.LastModified)
                           .ToListAsync();

            return Mapper.Map<IList<ViewEffort>>(@efforts);
        }

        /// <summary>
        /// Finds Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        public async Task<ApplicationUser> FindApplicationUserById(int @id)
        {
            ApplicationUser @applicationUser = await Context.ApplicationUser
               .TagWith("FindApplicationUserById")
               .AsQueryable()
               .Include(x => x.ApplicationUserTokens)
               .Include(x => x.ApplicationUserRoles)
               .ThenInclude(x => x.ApplicationRole)
               .FirstOrDefaultAsync(x => x.Id == @id);

            if (@applicationUser == null)
            {
                // Log
                string @logData = @applicationUser.GetType().Name
                    + " with Email "
                    + @applicationUser.Email
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@applicationUser.GetType().Name
                    + " with Email "
                    + @applicationUser.Email
                    + " does not exist");
            }

            return @applicationUser;
        }

        /// <summary>
        /// Removes Effort By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveEffortById(int @id)
        {
            try
            {
                Effort @effort = await FindEffortById(@id);

                Context.Effort.Remove(@effort);

                await Context.SaveChangesAsync();

                // Log
                string @logData = @effort.GetType().Name
                    + " with Id "
                    + @effort.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindEffortById(@id);
            }
        }

        /// <summary>
        /// Finds Effort By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> FindEffortById(int @id)
        {
            Effort @effort = await Context.Effort
                .TagWith("FindEffortById")
                .FirstOrDefaultAsync(x => x.Id == @id);

            if (@effort == null)
            {
                // Log
                string @logData = @effort.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@effort.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @effort;
        }

        /// <summary>
        /// Finds Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        public async Task<Kind> FindKindById(int @id)
        {
            Kind @kind = await Context.Kind
                .TagWith("FindKindById")
                .FirstOrDefaultAsync(x => x.Id == @id);

            if (@kind == null)
            {
                // Log
                string @logData = @kind.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@kind.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @kind;
        }

        /// <summary>
        /// Add Start Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> AddStartEffort(AddEffort @viewmodel)
        {
            Effort @effort = new Effort
            {
                Active = true,
                ApplicationUser = await this.FindApplicationUserById(@viewmodel.ApplicationUserId),
                Start = DateTime.Now,
                Kind = await this.FindKindById((int)EffortKinds.Start)
            };

            await Context.Effort.AddAsync(@effort);

            return @effort;
        }

        /// <summary>
        /// Add Pause Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> AddPauseEffort(AddEffort @viewmodel)
        {
            Effort @effort = new Effort
            {
                Active = true,
                ApplicationUser = await this.FindApplicationUserById(@viewmodel.ApplicationUserId),
                Start = DateTime.Now,
                Kind = await this.FindKindById((int)EffortKinds.Pause)
            };

            await Context.Effort.AddAsync(@effort);

            return @effort;
        }

        /// <summary>
        /// Add Resume Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> AddResumeEffort(AddEffort @viewmodel)
        {
            Effort @effort = new Effort
            {
                Active = true,
                ApplicationUser = await this.FindApplicationUserById(@viewmodel.ApplicationUserId),
                Start = DateTime.Now,
                Kind = await this.FindKindById((int)EffortKinds.Resume)
            };

            await Context.Effort.AddAsync(@effort);

            return @effort;
        }

        /// <summary>
        /// Add Stop Effort
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Effort> AddStopEffort(AddEffort @viewmodel)
        {
            Effort @effort = new Effort
            {
                Active = true,
                ApplicationUser = await this.FindApplicationUserById(@viewmodel.ApplicationUserId),
                Start = DateTime.Now,
                Kind = await this.FindKindById((int)EffortKinds.Stop)
            };

            await Context.Effort.AddAsync(@effort);

            return @effort;
        }

        /// <summary>
        /// De Activates Stop
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task DeActivateStop(AddEffort @viewmodel)
        {
            Effort @effort = await this.FindFormerDayActiveEffortByApplicationUserId(@viewmodel.ApplicationUserId);

            if (@effort != null)
            {
                if (@effort.Kind.Id.Equals((int)EffortKinds.Stop))
                {
                    @effort.Active = false;
                    @effort.Finish = DateTime.Now;

                    Context.Effort.Update(@effort);

                    // Log
                    string @logData = @effort.GetType().Name
                        + " with Id "
                        + @effort.Id
                        + " was updated at "
                        + DateTime.Now.ToShortTimeString();

                    Logger.WriteUpdateItemLog(@logData);
                }
                else
                {
                    throw new Exception(@effort.GetType().Name
                      + " with Id "
                      + @effort.Id
                      + " can not be stopped");
                }
            }
        }

        /// <summary>
        /// Starts
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        public async Task<ViewEffort> Start(AddEffort @viewmodel)
        {
            await DeActivateStop(@viewmodel);

            Effort @effort = await AddStartEffort(@viewmodel);

            await Context.SaveChangesAsync();

            // Log
            string @logData = @effort.GetType().Name
                + " with Id "
                + @effort.Id
                + " was Added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);           

            return Mapper.Map<ViewEffort>(@effort);
        }

        /// <summary>
        /// De Activates Start
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task DeActivateStart(AddEffort @viewmodel)
        {
            Effort @effort = await this.FindCurrentDayActiveEffortByApplicationUserId(@viewmodel.ApplicationUserId);

            if (@effort != null)
            {
                if (@effort.Kind.Id.Equals((int)EffortKinds.Start) || @effort.Kind.Id.Equals((int)EffortKinds.Resume))
                {
                    @effort.Active = false;
                    @effort.Finish = DateTime.Now;

                    Context.Effort.Update(@effort);

                    // Log
                    string @logData = @effort.GetType().Name
                        + " with Id "
                        + @effort.Id
                        + " was updated at "
                        + DateTime.Now.ToShortTimeString();

                    Logger.WriteUpdateItemLog(@logData);
                }
                else
                {
                    throw new Exception(@effort.GetType().Name
                      + " with Id "
                      + @effort.Id
                      + " can not be paused");
                }
            }
            else
            {
                // Log
                string @logData = @effort.GetType().Name
                    + " for Application User"
                    + viewmodel.ApplicationUserId
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@effort.GetType().Name
                     + " was not started");
            }
        }

        /// <summary>
        /// Pauses
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        public async Task<ViewEffort> Pause(AddEffort @viewmodel)
        {
            await DeActivateStart(@viewmodel);

            Effort @effort = await AddPauseEffort(@viewmodel);

            await Context.SaveChangesAsync();

            // Log
            string @logData = @effort.GetType().Name
                + " with Id "
                + @effort.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);            

            return Mapper.Map<ViewEffort>(@effort);
        }

        /// <summary>
        /// De Activates Pause
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task DeActivatePause(AddEffort @viewmodel)
        {
            Effort @effort = await this.FindCurrentDayActiveEffortByApplicationUserId(@viewmodel.ApplicationUserId);

            if (@effort != null)
            {
                if (@effort.Kind.Id.Equals((int)EffortKinds.Pause))
                {
                    @effort.Active = false;
                    @effort.Finish = DateTime.Now;

                    Context.Effort.Update(@effort);

                    // Log
                    string @logData = @effort.GetType().Name
                        + " with Id "
                        + @effort.Id
                        + " was updated at "
                        + DateTime.Now.ToShortTimeString();

                    Logger.WriteUpdateItemLog(@logData);
                }
                else
                {
                    throw new Exception(@effort.GetType().Name
                      + " with Id "
                      + @effort.Id
                      + " can not be paused");
                }
            }
            else
            {
                // Log
                string @logData = @effort.GetType().Name
                    + " for Application User"
                    + viewmodel.ApplicationUserId
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@effort.GetType().Name
                     + " was not started");
            }
        }

        /// <summary>
        /// Resumes
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        public async Task<ViewEffort> Resume(AddEffort @viewmodel)
        {
            await DeActivatePause(@viewmodel);

            Effort @effort = await AddResumeEffort(@viewmodel);

            await Context.SaveChangesAsync();

            // Log
            string @logData = @effort.GetType().Name
                + " with Id "
                + @effort.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);           

            return Mapper.Map<ViewEffort>(@effort);
        }

        /// <summary>
        /// De Activates Resume
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task DeActivateResume(AddEffort @viewmodel)
        {
            Effort @effort = await FindCurrentDayActiveEffortByApplicationUserId(@viewmodel.ApplicationUserId);

            if (@effort != null)
            {
                if (@effort.Kind.Id.Equals((int)EffortKinds.Resume) || @effort.Kind.Id.Equals((int)EffortKinds.Start))
                {
                    effort.ApplicationUser = await FindApplicationUserById(@viewmodel.ApplicationUserId);
                    @effort.Active = false;
                    @effort.Finish = DateTime.Now;

                    Context.Effort.Update(@effort);

                    // Log
                    string @logData = @effort.GetType().Name
                        + " with Id "
                        + @effort.Id
                        + " was updated at "
                        + DateTime.Now.ToShortTimeString();

                    Logger.WriteUpdateItemLog(@logData);
                }
                else
                {
                    throw new Exception(@effort.GetType().Name
                      + " with Id "
                      + @effort.Id
                      + " can not be stoppped");
                }
            }
            else
            {
                // Log
                string @logData = @effort.GetType().Name                  
                    + " for Application User" 
                    + viewmodel.ApplicationUserId
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@effort.GetType().Name
                     + " was not started");               
            }
        }

        /// <summary>
        /// Stops
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="AddEffort"/></param>
        /// <returns>Instance of <see cref="Task{ViewEffort}"/></returns>
        public async Task<ViewEffort> Stop(AddEffort @viewmodel)
        {
            await DeActivateResume(@viewmodel);

            Effort @effort = await AddStopEffort(@viewmodel);

            await Context.SaveChangesAsync();

            // Log
            string @logData = @effort.GetType().Name
                + " with Id "
                + @effort.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);            

            return Mapper.Map<ViewEffort>(@effort);
        }
    }
}
