
using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateMonth"/> class. Implements <see cref="IUpdateBase"/>
    /// </summary>
    public class UpdateMonth : IUpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateMonth"/>
        /// </summary>
        public UpdateMonth() 
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        public int Id { get; set; }

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
