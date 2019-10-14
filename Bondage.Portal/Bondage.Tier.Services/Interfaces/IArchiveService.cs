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

        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ViewArchive> AddArchive(AddArchive viewModel);

        Task<ViewArchive> UpdateArchive(UpdateArchive viewModel);

        Task<Archive> CheckName(AddArchive viewModel);
    }
}
