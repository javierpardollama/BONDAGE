using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Bondage.Tier.ViewModels.Interfaces.Views;

namespace Bondage.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewApplicationUser"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("application-user")]
    public class ViewApplicationUser : IViewKey, IViewBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewApplicationUser"/>
        /// </summary>
        public ViewApplicationUser()
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
        /// Gets or Sets <see cref="Email"/>
        /// </summary>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Initial"/>
        /// </summary>
        [XmlElement("initial")]
        public string Initial => Email?.Substring(0, 1).ToUpper();

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserRoles"/>
        /// </summary>
        [XmlArray("application-user-roles")]
        public virtual ICollection<ViewApplicationUserRole> ApplicationUserRoles { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationRoles"/>
        /// </summary>
        [XmlArray("application-roles")]
        public virtual ICollection<ViewApplicationRole> ApplicationRoles => ApplicationUserRoles?.AsQueryable().Select(x => x.ApplicationRole).ToList();

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserTokens"/>
        /// </summary>
        [XmlArray("application-user-tokens")]
        public virtual ICollection<ViewApplicationUserToken> ApplicationUserTokens { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserToken"/>
        /// </summary>
        [XmlElement("application-user-token")]
        public virtual ViewApplicationUserToken ApplicationUserToken => ApplicationUserTokens?.AsQueryable().LastOrDefault();
    }
}
