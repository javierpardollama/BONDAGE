using System;
using System.Xml.Serialization;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewDay"/> class.
    /// </summary>
    [XmlRoot("day")]
    public class ViewDay
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewDay"/>
        /// </summary>
        public ViewDay()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Absence"/>
        /// </summary>
        [XmlElement("absence")]
        public ViewAbsence Absence { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Date"/>
        /// </summary>
        [XmlElement("date")]
        public DateTime Date { get; set; }
    }
}
