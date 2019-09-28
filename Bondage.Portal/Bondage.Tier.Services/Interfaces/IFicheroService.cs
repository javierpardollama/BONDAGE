using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
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
    }
}
