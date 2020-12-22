using System;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewEffort"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("absence")]
    public class ViewAbsence : IViewKey, IViewBase
    {

        /// <summary>
        /// Initializes a new Instance of <see cref="ViewAbsence"/>
        /// </summary>
        public ViewAbsence()
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
        /// Gets or Sets <see cref="Type"/>
        /// </summary>
        [XmlElement("type")]
        public ViewGrade Type { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Date"/>
        /// </summary>
        [XmlElement("date")]
        public DateTime Date { get; set; }
    }
}
