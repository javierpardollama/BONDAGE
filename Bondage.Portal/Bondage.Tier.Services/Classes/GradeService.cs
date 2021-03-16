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
    /// Represents a <see cref="GradeService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IGradeService"/>
    /// </summary>
    public class GradeService : BaseService, IGradeService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="GradeService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public GradeService(IApplicationContext @context,
                              IMapper @mapper,
                              ILogger<GradeService> @logger) : base(@context,
                                                                      @mapper,
                                                                      @logger)
        {
        }

        /// <summary>
        /// Adds Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{ViewGrade}"/></returns>
        public async Task<ViewGrade> AddGrade(AddGrade @viewModel)
        {
            await CheckName(@viewModel);

            Grade @Grade = new()
            {
                Name = @viewModel.Name,
                ImageUri = @viewModel.ImageUri
            };

            try
            {
                await Context.Grade.AddAsync(@Grade);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Grade.GetType().Name
                + " with Id "
                + @Grade.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewGrade>(@Grade);
        }

        /// <summary>
        /// Finds All Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewGrade}}"/></returns>
        public async Task<ICollection<ViewGrade>> FindAllGrade()
        {
            IList<Grade> @Grades = await Context.Grade
                .TagWith("FindAllGrade")
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<IList<ViewGrade>>(@Grades);
        }
       

        /// <summary>
        /// Finds Grade By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        public async Task<Grade> FindGradeById(int @id)
        {
            Grade @Grade = await Context.Grade
                 .TagWith("FindGradeById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@Grade == null)
            {
                // Log
                string @logData = @Grade.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@Grade.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @Grade;
        }

        /// <summary>
        /// Removes Grade By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveGradeById(int @id)
        {
            try
            {
                Grade @Grade = await FindGradeById(@id);

                Context.Grade.Remove(@Grade);

                await Context.SaveChangesAsync();

                // Log
                string @logData = @Grade.GetType().Name
                    + " with Id "
                    + @Grade.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindGradeById(@id);
            }
        }

        /// <summary>
        /// Updates Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateGrade"/></param>
        /// <returns>Instance of <see cref="Task{ViewGrade}"/></returns>
        public async Task<ViewGrade> UpdateGrade(UpdateGrade @viewModel)
        {
            await CheckName(@viewModel);

            Grade @Grade = await FindGradeById(@viewModel.Id);
            @Grade.Name = @viewModel.Name;
            @Grade.ImageUri = @viewModel.ImageUri;

            try
            {
                Context.Grade.Update(@Grade);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Grade.GetType().Name
                + " with Id "
                + @Grade.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewGrade>(@Grade);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        public async Task<Grade> CheckName(AddGrade @viewModel)
        {
            Grade @Grade = await Context.Grade
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name);

            if (@Grade != null)
            {
                // Log
                string @logData = @Grade.GetType().Name
                    + " with Name "
                    + @Grade.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Grade.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @Grade;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateGrade"/></param>
        /// <returns>Instance of <see cref="Task{Grade}"/></returns>
        public async Task<Grade> CheckName(UpdateGrade @viewModel)
        {
            Grade @Grade = await Context.Grade
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name && x.Id != viewModel.Id);

            if (@Grade != null)
            {
                // Log
                string @logData = @Grade.GetType().Name
                    + " with Name "
                    + @Grade.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Grade.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return Grade;
        }
    }
}