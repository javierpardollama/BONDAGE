using System;

using Bondage.Tier.ViewModels.Interfaces.Additions;

namespace Bondage.Tier.ViewModels.Classes.Additions
{
    /// <summary>
    /// Represents a <see cref="AddAbsence"/> class. Implements <see cref="IAddBase"/>
    /// </summary>
    public class AddAbsence : IAddBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="AddAbsence"/>
        /// </summary>
        public AddAbsence()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="GradeId"/>
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Finish"/>
        /// </summary>
        public DateTime Finish { get; set; }
    }
}
