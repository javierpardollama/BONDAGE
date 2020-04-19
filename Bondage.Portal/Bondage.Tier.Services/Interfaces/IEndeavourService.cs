using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IEndeavourService : IBaseService
    {
        Task<ICollection<ViewEndeavour>> FindAllEndeavour();

        Task<ICollection<ViewEndeavour>> FindAllEndeavourByApplicationUserById(int id);

        Task<ApplicationUser> FindApplicationUserById(int id);

        Task<ViewEndeavour> Start(AddEndeavour viewModel);

        Task<ViewEndeavour> Finish(UpdateEndeavour viewModel);

        Task RemoveEndeavourById(int id);

        Task<Endeavour> FindEndeavourById(int id);
    }
}
