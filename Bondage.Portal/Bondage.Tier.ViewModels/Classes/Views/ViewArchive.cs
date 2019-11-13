using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    [XmlRoot("archive")]
    public class ViewArchive : IViewKey, IViewBase
    {
        public ViewArchive()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        [XmlElement("by")]
        public virtual ViewApplicationUser By { get; set; }

        [XmlIgnore]
        public byte[] Data { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
