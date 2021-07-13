using System;

using Bondage.Tier.ViewModels.Interfaces.Updates;

namespace Bondage.Tier.ViewModels.Classes.Updates
{
    /// <summary>
    /// Represents a <see cref="UpdateAbsence"/> class. Implements <see cref="IUpdateBase"/>
    /// </summary>

    public class UpdateAbsence : IUpdateBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="UpdateAbsence"/>
        /// </summary>
        public UpdateAbsence()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        public int Id { get; set; }

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
