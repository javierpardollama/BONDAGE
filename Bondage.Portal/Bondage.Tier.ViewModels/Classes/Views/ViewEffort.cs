﻿using System;
using System.Xml.Serialization;

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
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        [XmlElement("start")]
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Stop"/>
        /// </summary>
        [XmlElement("stop")]
        public DateTime? Finish { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Kind"/>
        /// </summary>
        [XmlElement("kind")]
        public ViewKind Kind { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Active"/>
        /// </summary>
        [XmlElement("active")]
        public bool Active { get; set; }
    }
}
