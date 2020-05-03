using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewApplicationRole"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("application-role")]
    public class ViewApplicationRole : IViewKey, IViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewApplicationRole"/>
        /// </summary>
        public ViewApplicationRole()
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
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        [XmlElement("image-uri")]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserRoles"/>
        /// </summary>
        [XmlArray("application-user-roles")]
        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUsers"/>
        /// </summary>
        [XmlArray("application-users")]
        public virtual ICollection<ViewApplicationUser> ApplicationUsers => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationUser).ToList();
    }
}
