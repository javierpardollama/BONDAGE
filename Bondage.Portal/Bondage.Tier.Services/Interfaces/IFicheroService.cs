using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IFicheroService : IBaseService
    {
        Task<Fichero> FindFicheroById(int id);

        Task RemoveFicheroById(int id);

        Task<IList<ViewFichero>> FindAllFichero();

        Task<IList<ViewFichero>> FindAllFicheroByApplicationUserId(int id);

        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ViewFichero> AddFichero(AddFichero viewModel);

        Task<ViewFichero> UpdateFichero(UpdateFichero viewModel);

        Task<Fichero> CheckName(AddFichero viewModel);
    }
}
