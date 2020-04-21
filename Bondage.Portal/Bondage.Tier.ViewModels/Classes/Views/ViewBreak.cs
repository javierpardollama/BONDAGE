using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    [XmlRoot("break")]
    public class ViewBreak : IViewKey, IViewBase
    {
        public ViewBreak()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        [XmlElement("last-modified")]
        public DateTime? Date { get; set; }

        [XmlElement("effort")]
        public virtual ViewEffort Effort { get; set; }

        [XmlElement("kind")]
        public virtual ViewKind Kind { get; set; }
    }
}
