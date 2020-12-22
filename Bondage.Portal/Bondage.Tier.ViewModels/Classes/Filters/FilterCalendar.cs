using Bondage.Tier.ViewModels.Interfaces.Filters;

namespace Bondage.Tier.ViewModels.Classes.Filters
{
    /// <summary>
    /// Represents a <see cref="FilterCalendar"/> class. Implements <see cref="IFilterBase"/>
    /// </summary>
    public class FilterCalendar : IFilterBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="FilterCalendar"/>
        /// </summary>
        public FilterCalendar()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserId"/>
        /// </summary>
        public int ApplicationUserId { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Year"/>
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Month"/>
        /// </summary>
        public int Month { get; set; }
    }
}
