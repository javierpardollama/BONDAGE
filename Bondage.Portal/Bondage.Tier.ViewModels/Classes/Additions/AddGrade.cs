using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddGrade"/> class. Implements <see cref="IAddBase"/>
    /// </summary>
    public class AddGrade : IAddBase
    {
        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }
    }
}
