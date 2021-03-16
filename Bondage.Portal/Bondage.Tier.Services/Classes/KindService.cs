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
    /// Represents a <see cref="KindService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IKindService"/>
    /// </summary>
    public class KindService : BaseService, IKindService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="KindService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public KindService(IApplicationContext @context,
                              IMapper @mapper,
                              ILogger<KindService> @logger) : base(@context,
                                                                      @mapper,
                                                                      @logger)
        {
        }

        /// <summary>
        /// Adds Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddKind"/></param>
        /// <returns>Instance of <see cref="Task{ViewKind}"/></returns>
        public async Task<ViewKind> AddKind(AddKind @viewModel)
        {
            await CheckName(@viewModel);

            Kind @Kind = new()
            {
                Name = @viewModel.Name,
                ImageUri = @viewModel.ImageUri
            };

            try
            {
                await Context.Kind.AddAsync(@Kind);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Kind.GetType().Name
                + " with Id "
                + @Kind.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewKind>(@Kind);
        }

        /// <summary>
        /// Finds All Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task{ICollection{ViewKind}}"/></returns>
        public async Task<ICollection<ViewKind>> FindAllKind()
        {
            IList<Kind> @Kinds = await Context.Kind
                .TagWith("FindAllKind")
                .AsNoTracking()
                .ToListAsync();

            return Mapper.Map<IList<ViewKind>>(@Kinds);
        }


        /// <summary>
        /// Finds Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        public async Task<Kind> FindKindById(int @id)
        {
            Kind @Kind = await Context.Kind
                 .TagWith("FindKindById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@Kind == null)
            {
                // Log
                string @logData = @Kind.GetType().Name
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@Kind.GetType().Name
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @Kind;
        }

        /// <summary>
        /// Removes Kind By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public async Task RemoveKindById(int @id)
        {
            try
            {
                Kind @Kind = await FindKindById(@id);

                Context.Kind.Remove(@Kind);

                await Context.SaveChangesAsync();

                // Log
                string @logData = @Kind.GetType().Name
                    + " with Id "
                    + @Kind.Id
                    + " was removed at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteDeleteItemLog(@logData);
            }
            catch (DbUpdateConcurrencyException)
            {
                await FindKindById(@id);
            }
        }

        /// <summary>
        /// Updates Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateKind"/></param>
        /// <returns>Instance of <see cref="Task{ViewKind}"/></returns>
        public async Task<ViewKind> UpdateKind(UpdateKind @viewModel)
        {
            await CheckName(@viewModel);

            Kind @Kind = await FindKindById(@viewModel.Id);
            @Kind.Name = @viewModel.Name;
            @Kind.ImageUri = @viewModel.ImageUri;

            try
            {
                Context.Kind.Update(@Kind);

                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await CheckName(@viewModel);
            }

            // Log
            string @logData = @Kind.GetType().Name
                + " with Id "
                + @Kind.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(@logData);

            return Mapper.Map<ViewKind>(@Kind);
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddKind"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        public async Task<Kind> CheckName(AddKind @viewModel)
        {
            Kind @Kind = await Context.Kind
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name);

            if (@Kind != null)
            {
                // Log
                string @logData = @Kind.GetType().Name
                    + " with Name "
                    + @Kind.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Kind.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return @Kind;
        }

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateKind"/></param>
        /// <returns>Instance of <see cref="Task{Kind}"/></returns>
        public async Task<Kind> CheckName(UpdateKind @viewModel)
        {
            Kind @Kind = await Context.Kind
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == @viewModel.Name && x.Id != viewModel.Id);

            if (@Kind != null)
            {
                // Log
                string @logData = @Kind.GetType().Name
                    + " with Name "
                    + @Kind.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(@logData);

                throw new Exception(@Kind.GetType().Name
                    + " with Name "
                    + @viewModel.Name
                    + " already exists");
            }

            return Kind;
        }
    }
}