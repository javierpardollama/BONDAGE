using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IEndeavourService : IBaseService
    {
        Task<ICollection<ViewEndeavour>> FindAllEndeavour();

        Task<ICollection<ViewEndeavour>> FindAllEndeavourByApplicationUserById(int id);

        Task<ApplicationUser> FindApplicationUserById(int id);

        Task<ViewEndeavour> Start(AddEndeavour viewModel);

        Task<ViewEndeavour> Pause(AddEndeavour viewModel);

        Task<ViewEndeavour> Resume(AddEndeavour viewModel);

        Task<ViewEndeavour> Stop(AddEndeavour viewModel);

        Task RemoveEndeavourById(int id);

        Task<Endeavour> FindEndeavourById(int id);

        Task<Kind> FindKindById(int id);

    }
}
