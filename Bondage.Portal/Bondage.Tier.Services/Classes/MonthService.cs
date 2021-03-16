using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
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
    /// <summary>
    /// Represents a <see cref="MonthService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IMonthService"/>
    /// </summary>
    public class MonthService : BaseService, IMonthService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="MonthService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public MonthService(IApplicationContext @context,
                              IMapper @mapper,
                              ILogger<MonthService> @logger) : base(@context,
                                                                      @mapper,
                                                                      @logger)
        {
        }

        /// <summary>
        /// Adds Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddMonth"/></param>
        /// <returns>Instance of <see cref="Task{ViewMonth}"/></returns>
        public async Task<ViewMonth> AddMonth(AddMonth @viewModel)
        {
            await CheckName(@viewModel);

            Month @Month = new()
            {
                Name = @viewModel.Name,
                Number = @viewModel.Number
            };

            try
            {
                await Context.Month.AddAsync(@Month);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Month.GetType().Name
                + " with Id "
                + @Month.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewMonth>(@Month);
        }

        /// <summary>
        /// Finds All Month
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewMonth}}"/></returns>
        public async Task<ICollection<ViewMonth>> FindAllMonth()
        {
            IList<Month> @Months = await Context.Month
                .TagWith("FindAllMonth")
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<IList<ViewMonth>>(@Months);
        }


        /// <summary>
        /// Finds Month By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        public async Task<Month> FindMonthById(int @id)
        {
            Month @Month = await Context.Month
                 .TagWith("FindMonthById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@Month == null)
            {
                // Log
                string @logData = @Month.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@Month.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @Month;
        }

        /// <summary>
        /// Removes Month By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveMonthById(int @id)
        {
            try
            {
                Month @Month = await FindMonthById(@id);

                Context.Month.Remove(@Month);

                await Context.SaveChangesAsync();

                // Log
                string @logData = @Month.GetType().Name
                    + " with Id "
                    + @Month.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindMonthById(@id);
            }
        }

        /// <summary>
        /// Updates Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateMonth"/></param>
        /// <returns>Instance of <see cref="Task{ViewMonth}"/></returns>
        public async Task<ViewMonth> UpdateMonth(UpdateMonth @viewModel)
        {
            await CheckName(@viewModel);

            Month @Month = await FindMonthById(@viewModel.Id);
            @Month.Name = @viewModel.Name;
            @Month.Number = @viewModel.Number;

            try
            {
                Context.Month.Update(@Month);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Month.GetType().Name
                + " with Id "
                + @Month.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewMonth>(@Month);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddMonth"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        public async Task<Month> CheckName(AddMonth @viewModel)
        {
            Month @Month = await Context.Month
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name);

            if (@Month != null)
            {
                // Log
                string @logData = @Month.GetType().Name
                    + " with Name "
                    + @Month.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Month.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @Month;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateMonth"/></param>
        /// <returns>Instance of <see cref="Task{Month}"/></returns>
        public async Task<Month> CheckName(UpdateMonth @viewModel)
        {
            Month @Month = await Context.Month
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name && x.Id != viewModel.Id);

            if (@Month != null)
            {
                // Log
                string @logData = @Month.GetType().Name
                    + " with Name "
                    + @Month.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Month.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return Month;
        }
    }
}