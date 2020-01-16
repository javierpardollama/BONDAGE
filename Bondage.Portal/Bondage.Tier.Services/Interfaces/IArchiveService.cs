using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IArchiveService : IBaseService
    {
        Task<Archive> FindArchiveById(int id);

        Task RemoveArchiveById(int id);

        Task<IList<ViewArchive>> FindAllArchive();

        Task<IList<ViewArchive>> FindAllArchiveByApplicationUserId(int id);

        Task<IList<ViewArchive>> FindAllSharedArchiveByApplicationUserId(int id);

        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ApplicationUser> FindApplicationUserById(int id);

        Task<ViewArchive> AddArchive(AddArchive viewModel);

        void AddApplicationUserArchive(AddArchive viewModel, Archive entity);

        void AddArchiveVersion(AddArchive viewModel, Archive entity);

        Task<ViewArchive> UpdateArchive(UpdateArchive viewModel);

        void UpdateApplicationUserArchive(UpdateArchive viewModel, Archive entity);

        void UpdateArchiveVersion(UpdateArchive viewModel, Archive entity);

        Task<Archive> CheckName(AddArchive viewModel);

        Task<Archive> CheckName(UpdateArchive viewModel);
    }
}
