using System;
using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewApplicationUserArchive : IViewBase, IViewKey
    {
        public ViewApplicationUserArchive()
        {
        }

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public virtual ViewArchive Archive { get; set; }

        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
