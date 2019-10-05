using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    public class AddFichero
    {
        public AddFichero()
        {
        }

        public virtual ViewApplicationUser By { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }
    }
}
