using System;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    public class ViewFichero : IViewKey, IViewBase
    {
        public ViewFichero()
        {
        }

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public virtual ViewApplicationUser By { get; set; }

        public byte[] Data { get; set; }

        public string Name { get; set; }
    }
}
