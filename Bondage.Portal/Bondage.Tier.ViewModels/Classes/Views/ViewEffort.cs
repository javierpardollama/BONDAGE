using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Bondage.Tier.Constants.Enums;
using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewEffort"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("effort")]
    public class ViewEffort : IViewKey, IViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewEffort"/>
        /// </summary>
        public ViewEffort()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        [XmlElement("application-user")]
        public virtual ViewApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Breaks"/>
        /// </summary>
        [XmlArray("breaks")]
        public virtual ICollection<ViewBreak> Breaks { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        [XmlElement("start")]
        public DateTime? Start => Breaks?.AsQueryable().FirstOrDefault(x => x.Kind.Id == (int)EffortKinds.Start).Start;

        /// <summary>
        /// Gets or Sets <see cref="Stop"/>
        /// </summary>
        [XmlElement("stop")]
        public DateTime? Stop => Breaks?.AsQueryable().FirstOrDefault(x => x.Kind.Id == (int)EffortKinds.Stop).Start;

        /// <summary>
        /// Gets or Sets <see cref="Current"/>
        /// </summary>
        [XmlElement("current")]
        public ViewBreak Current => Breaks?.AsQueryable().FirstOrDefault(x => x.Active);
    }
}
