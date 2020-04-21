using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Bondage.Tier.Constants.Enums;
using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    [XmlRoot("effort")]
    public class ViewEffort : IViewKey, IViewBase
    {
        public ViewEffort()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        [XmlElement("application-user")]
        public virtual ViewApplicationUser ApplicationUser { get; set; }

        [XmlArray("breaks")]
        public virtual ICollection<ViewBreak> Breaks { get; set; }

        [XmlElement("start")]
        public DateTime? Start => Breaks?.AsQueryable().FirstOrDefault(x => x.Kind.Id == (int)EffortKinds.Start).Date;

        [XmlElement("stop")]
        public DateTime? Stop => Breaks?.AsQueryable().FirstOrDefault(x => x.Kind.Id == (int)EffortKinds.Stop).Date;
    }
}
