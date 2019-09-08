using System;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserToken : IViewBase
    {
        public ViewApplicationUserToken()
        {
        }

        public DateTime LastModified { get; set; }

        public string Value { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
