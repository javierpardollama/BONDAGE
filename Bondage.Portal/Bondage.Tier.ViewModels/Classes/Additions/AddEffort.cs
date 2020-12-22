using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddEffort"/> class. Implements <see cref="IAddBase"/>
    /// </summary>
    public class AddEffort : IAddBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AddEffort"/>
        /// </summary>
        public AddEffort()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }
    }
}
