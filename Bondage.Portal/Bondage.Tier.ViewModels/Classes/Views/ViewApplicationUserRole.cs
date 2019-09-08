using System;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserRole : IViewBase, IViewKey
    {
        public ViewApplicationUserRole()
        {
        }

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public virtual ViewApplicationRole ApplicationRole { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
