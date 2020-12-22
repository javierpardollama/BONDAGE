using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateGrade"/> class. Implements <see cref="IUpdateBase"/>
    /// </summary>
    public class UpdateGrade : IUpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateGrade"/>
        /// </summary>
        public UpdateGrade()
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
