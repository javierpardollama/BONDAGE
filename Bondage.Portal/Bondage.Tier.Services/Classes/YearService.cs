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
    /// Represents a <see cref="YearService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IYearService"/>
    /// </summary>
    public class YearService : BaseService, IYearService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="YearService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public YearService(IApplicationContext @context,
                              IMapper @mapper,
                              ILogger<YearService> @logger) : base(@context,
                                                                      @mapper,
                                                                      @logger)
        {
        }

        /// <summary>
        /// Adds Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddYear"/></param>
        /// <returns>Instance of <see cref="Task{ViewYear}"/></returns>
        public async Task<ViewYear> AddYear(AddYear @viewModel)
        {
            await CheckNumber(@viewModel);

            Year @Year = new()
            {
                Number = @viewModel.Number            };

            try
            {
                await Context.Year.AddAsync(@Year);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckNumber(@viewModel);
            }

            // Log
            string @logData = @Year.GetType().Name
                + " with Id "
                + @Year.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewYear>(@Year);
        }

        /// <summary>
        /// Finds All Year
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewYear}}"/></returns>
        public async Task<ICollection<ViewYear>> FindAllYear()
        {
            IList<Year> @Years = await Context.Year
                .TagWith("FindAllYear")
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<IList<ViewYear>>(@Years);
        }


        /// <summary>
        /// Finds Year By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        public async Task<Year> FindYearById(int @id)
        {
            Year @Year = await Context.Year
                 .TagWith("FindYearById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@Year == null)
            {
                // Log
                string @logData = @Year.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@Year.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @Year;
        }

        /// <summary>
        /// Removes Year By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveYearById(int @id)
        {
            try
            {
                Year @Year = await FindYearById(@id);

                Context.Year.Remove(@Year);

                await Context.SaveChangesAsync();

                // Log
                string @logData = @Year.GetType().Name
                    + " with Id "
                    + @Year.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindYearById(@id);
            }
        }

        /// <summary>
        /// Updates Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateYear"/></param>
        /// <returns>Instance of <see cref="Task{ViewYear}"/></returns>
        public async Task<ViewYear> UpdateYear(UpdateYear @viewModel)
        {
            await CheckNumber(@viewModel);

            Year @Year = await FindYearById(@viewModel.Id);
            @Year.Number = @viewModel.Number;

            try
            {
                Context.Year.Update(@Year);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckNumber(@viewModel);
            }

            // Log
            string @logData = @Year.GetType().Name
                + " with Id "
                + @Year.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewYear>(@Year);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddYear"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        public async Task<Year> CheckNumber(AddYear @viewModel)
        {
            Year @Year = await Context.Year
                 .TagWith("CheckNumber")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Number == @viewModel.Number);

            if (@Year != null)
            {
                // Log
                string @logData = @Year.GetType().Name
                    + " with Number "
                    + @Year.Number
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Year.GetType().Name
                    + " with Number "
                    + @viewModel.Number
                    + " already exists");
            }

            return @Year;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateYear"/></param>
        /// <returns>Instance of <see cref="Task{Year}"/></returns>
        public async Task<Year> CheckNumber(UpdateYear @viewModel)
        {
            Year @Year = await Context.Year
                 .TagWith("CheckNumber")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Number == @viewModel.Number && x.Id != viewModel.Id);

            if (@Year != null)
            {
                // Log
                string @logData = @Year.GetType().Name
                    + " with Number "
                    + @Year.Number
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Year.GetType().Name
                    + " with Number "
                    + @viewModel.Number
                    + " already exists");
            }

            return Year;
        }
    }
}