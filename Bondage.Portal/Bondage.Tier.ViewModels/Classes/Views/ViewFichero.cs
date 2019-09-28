using System;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewFichero : IViewKey, IViewBase
    {
        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public virtual ViewFichero Parent { get; set; }

        public bool Carpeta { get; set; }

        public virtual ViewApplicationUser By { get; set; }

        public string ImageUri { get; set; }
    }
}
