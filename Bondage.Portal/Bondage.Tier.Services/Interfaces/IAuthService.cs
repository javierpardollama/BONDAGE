using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Auth;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    public interface IAuthService : IBaseService
    {
        Task<ViewApplicationUser> SignIn(AuthSignIn viewModel);

        Task<ViewApplicationUser> SignIn(AuthJoinIn viewModel);

        Task<ViewApplicationUser> JoinIn(AuthJoinIn viewModel);

        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ApplicationUser> CheckEmail(AuthJoinIn viewModel);
    }
}
