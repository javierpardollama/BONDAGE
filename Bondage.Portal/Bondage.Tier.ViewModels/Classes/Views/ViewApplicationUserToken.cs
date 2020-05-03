using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewApplicationUserToken"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("application-user-token")]
    public class ViewApplicationUserToken : IViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewApplicationUserToken"/>
        /// </summary>
        public ViewApplicationUserToken()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Value"/>
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        [XmlElement("application-user")]
        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}