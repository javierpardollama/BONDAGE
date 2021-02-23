using System;

using Bondage.Tier.ViewModels.Interfaces.Filters;

namespace Bondage.Tier.ViewModels.Classes.Filters
{
    /// <summary>
    /// Represents a <see cref="FilterAbsence"/> class. Implements <see cref="IFilterBase"/>
    /// </summary>

    public class FilterAbsence : IFilterBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="FIlterAbsence"/>
        /// </summary>
        public FilterAbsence()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Date"/>
        /// </summary>
        public DateTime Date { get; set; }
    }
}
