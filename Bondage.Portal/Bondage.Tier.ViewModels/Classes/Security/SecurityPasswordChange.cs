using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.ViewModels.Classes.Security
{
    public class SecurityPasswordChange
    {
        public SecurityPasswordChange()
        {
        }

        public virtual ViewApplicationUser ApplicationUser { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
