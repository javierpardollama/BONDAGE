using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Security;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="ISecurityService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface ISecurityService : IBaseService
    {
        /// <summary>
        /// Finds Application User By Email
        /// </summary>
        /// <param name="email">Injected <see cref="string"/></param>
        /// <returns>Instance of <see cref="ApplicationUser"/></returns>
        Task<ApplicationUser> FindApplicationUserByEmail(string @email);

        /// <summary>
        /// Resets Password
        /// </summary>
        /// <param name="viewModel">Injected <see cref="SecurityPasswordReset"/></param>
        /// <returns>Instance of <see cref="ViewApplicationUser"/></returns>
        Task<ViewApplicationUser> ResetPassword(SecurityPasswordReset @viewModel);

        /// <summary>
        /// Changes Password
        /// </summary>
        /// <param name="viewModel">Injected <see cref="SecurityPasswordChange"/></param>
        /// <returns>Instance of <see cref="ViewApplicationUser"/></returns>
        Task<ViewApplicationUser> ChangePassword(SecurityPasswordChange @viewModel);

        /// <summary>
        /// Changes Email
        /// </summary>
        /// <param name="viewModel">Injected <see cref="SecurityEmailChange"/></param>
        /// <returns>Instance of <see cref="ViewApplicationUser"/></returns>
        Task<ViewApplicationUser> ChangeEmail(SecurityEmailChange @viewModel);
    }
}
