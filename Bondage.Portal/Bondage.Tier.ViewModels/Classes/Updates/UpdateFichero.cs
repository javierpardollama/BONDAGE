using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    public class UpdateFichero : UpdateBase
    {
        public UpdateFichero()
        {
        }

        public virtual ViewApplicationUser By { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }
    }
}
