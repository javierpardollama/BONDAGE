using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Security;
using Bondage.Tier.ViewModels.Classes.Views;
using System.Threading.Tasks;

namespace Bondage.Tier.Services.Interfaces
{
    public interface ISecurityService : IBaseService
    {
        Task<ApplicationUser> FindApplicationUserByEmail(string email);

        Task<ViewApplicationUser> ResetPassword(SecurityPasswordReset viewModel);

        Task<ViewApplicationUser> ChangePassword(SecurityPasswordChange viewModel);

        Task<ViewApplicationUser> ChangeEmail(SecurityEmailChange viewModel);
    }
}
