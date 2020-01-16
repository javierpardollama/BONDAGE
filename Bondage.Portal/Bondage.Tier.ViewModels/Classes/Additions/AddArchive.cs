using System.Collections.Generic;

using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    public class AddArchive
    {
        public AddArchive()
        {
        }

        public virtual ViewApplicationUser By { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public virtual ICollection<int> ApplicationUsersId { get; set; }
    }
}
