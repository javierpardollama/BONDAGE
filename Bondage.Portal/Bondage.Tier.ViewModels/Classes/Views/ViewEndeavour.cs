using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    [XmlRoot("endeavur")]
    public class ViewEndeavour : IViewKey, IViewBase
    {
        public ViewEndeavour()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        [XmlElement("application-user")]
        public virtual ViewApplicationUser ApplicationUser { get; set; }

        [XmlElement("start")]
        public DateTime Start { get; set; }

        [XmlElement("finish")]
        public DateTime Finish { get; set; }
    }
}
