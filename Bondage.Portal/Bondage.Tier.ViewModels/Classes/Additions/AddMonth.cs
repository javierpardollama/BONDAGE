
using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddMonth"/> class. Implements <see cref="IAddBase"/>
    /// </summary>
    public class AddMonth : IAddBase
    {
        /// Initializes a new Instance of <see cref="AddYear"/>
        /// </summary>
        public AddMonth()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Month"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Month"/>
        /// </summary>
        public int Number { get; set; }
    }
}
