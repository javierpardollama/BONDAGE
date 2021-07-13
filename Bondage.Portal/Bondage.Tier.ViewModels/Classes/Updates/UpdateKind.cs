
using Bondage.Tier.ViewModels.Interfaces.Updates;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateKind"/> class. Implements <see cref="IUpdateBase"/>
    /// </summary>
    public class UpdateKind : IUpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateKind"/>
        /// </summary>
        public UpdateKind()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ImageUri"/>
        /// </summary>
        public string ImageUri { get; set; }
    }
}
