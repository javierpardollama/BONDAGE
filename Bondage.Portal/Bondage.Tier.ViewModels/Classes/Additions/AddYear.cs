
using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddYear"/> class. Implements <see cref="IAddBase"/>
    /// </summary>
    public class AddYear : IAddBase
    {
        /// Initializes a new Instance of <see cref="AddYear"/>
        /// </summary>
        public AddYear()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Number"/>
        /// </summary>
        public int Number { get; set; }
    }
}
