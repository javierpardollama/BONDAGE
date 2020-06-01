using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewBreak"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("break")]
    public class ViewBreak : IViewKey, IViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewBreak"/>
        /// </summary>
        public ViewBreak()
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
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        [XmlElement("start")]
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Finish"/>
        /// </summary>
        [XmlElement("finish")]
        public DateTime? Finish { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Active"/>
        /// </summary>
        [XmlElement("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Effort"/>
        /// </summary>
        [XmlElement("effort")]
        public virtual ViewEffort Effort { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Kind"/>
        /// </summary>
        [XmlElement("kind")]
        public virtual ViewKind Kind { get; set; }
    }
}
