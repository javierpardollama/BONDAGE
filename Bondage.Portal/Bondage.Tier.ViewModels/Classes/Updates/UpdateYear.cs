using Bondage.Tier.ViewModels.Interfaces.Updates;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateYear"/> class. Implements <see cref="IUpdateBase"/>
    /// </summary>
    public class UpdateYear : IUpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateGrade"/>
        /// </summary>
        public UpdateYear()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Number"/>
        /// </summary>
        public int Number { get; set; }
    }
}
