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
    public class ArchiveService : BaseService, IArchiveService
    {
        private readonly UserManager<ApplicationUser> UserManager;

        public ArchiveService(UserManager<ApplicationUser> userManager,
                              IApplicationContext context,
                              IMapper mapper,
                              ILogger<ArchiveService> logger) : base(context, mapper, logger)
        {
            UserManager = userManager;
        }

        public async Task<Archive> FindArchiveById(int id)
        {
            Archive archive = await Context.Archive
                 .TagWith("FindArchiveById")
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (archive == null)
            {
                // Log
                string logData = archive.GetType().Name
                    + " with Id "
                    + id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(logData);

                throw new Exception(archive.GetType().Name
                    + " with Id "
                    + id
                    + " does not exist");
            }

            return archive;
        }

        public async Task RemoveArchiveById(int id)
        {
            Archive archive = await FindArchiveById(id);

            Context.Archive.Remove(archive);

            await Context.SaveChangesAsync();

            // Log
            string logData = archive.GetType().Name
                + " with Id "
                + archive.Id
                + " was removed at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteDeleteItemLog(logData);
        }

        public async Task<IList<ViewArchive>> FindAllArchive()
        {
            ICollection<Archive> archives = await Context.Archive
                .TagWith("FindAllArchive")
                .AsQueryable()
                .Include(x => x.By)
                .ToListAsync();

            return Mapper.Map<IList<ViewArchive>>(archives);
        }

        public async Task<IList<ViewArchive>> FindAllArchiveByApplicationUserId(int id)
        {
            ICollection<Archive> archives = await Context.Archive
               .TagWith("FindAllArchiveByApplicationUserId")
               .AsQueryable()
               .AsNoTracking()
               .Include(x => x.By)
               .Where(x => x.By.Id == id)
               .ToListAsync();

            return Mapper.Map<IList<ViewArchive>>(archives);
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

        public async Task<ViewArchive> AddArchive(AddArchive viewModel)
        {
            await CheckName(viewModel);

            Archive archive = new Archive
            {
                Name = viewModel.Name,
                Data = viewModel.Data,
                By = await FindApplicationUserByEmail(viewModel.By.Email)
            };

            await Context.Archive.AddAsync(archive);

            await Context.SaveChangesAsync();

            // Log
            string logData = archive.GetType().Name
                + " with Id "
                + archive.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(logData);

            return Mapper.Map<ViewArchive>(archive);
        }

        public async Task<ViewArchive> UpdateArchive(UpdateArchive viewModel)
        {
            Archive archive = await FindArchiveById(viewModel.Id);
            archive.Name = viewModel.Name;
            archive.Data = viewModel.Data;
            archive.By = await FindApplicationUserByEmail(viewModel.By.Email);

            Context.Archive.Update(archive);

            await Context.SaveChangesAsync();

            // Log
            string logData = archive.GetType().Name
                + " with Id "
                + archive.Id
                + " was modified at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteUpdateItemLog(logData);

            return Mapper.Map<ViewArchive>(archive);
        }

        public async Task<Archive> CheckName(AddArchive viewModel)
        {
            Archive archive = await Context.Archive
                 .TagWith("CheckName")
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Name == viewModel.Name);

            if (archive != null)
            {
                // Log
                string logData = archive.GetType().Name
                    + " with Name "
                    + archive.Name
                    + " was already found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemFoundLog(logData);

                throw new Exception(archive.GetType().Name
                    + " with Name "
                    + viewModel.Name
                    + " already exists");
            }

            return archive;
        }

    }
}
