using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Bondage.Tier.Contexts.Interfaces;
using Bondage.Tier.Entities.Classes;
using Bondage.Tier.Logging.Classes;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Filters;
using Bondage.Tier.ViewModels.Classes.Views;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bondage.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="CalendarService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="ICalendarService"/>
    /// </summary>
    public class CalendarService : BaseService, ICalendarService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="EffortService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger{EffortService}"/></param>
        public CalendarService(
            IApplicationContext @context,
            IMapper @mapper,
            ILogger<CalendarService> @logger) : base(@context, @mapper, @logger)
        {
        }

        /// <summary>
        /// Finds Absence By Date
        /// </summary>
        /// <param name="date">Injected <see cref="DateTime"/></param>
        /// <param name="@applicationUserId">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        public async Task<Absence> FindAbsenceByDate(DateTime @date, int @applicationUserId)
        {
            Absence @absence = await Context.Absence
              .TagWith("FindAbsenceByDate")
              .AsQueryable()
              .Include(x => x.ApplicationUser)
              .Include(x => x.Grade)
              .Where(x => x.ApplicationUser.Id == @applicationUserId)
              .FirstOrDefaultAsync(x => x.Date == @date);                                        

            if (@absence == null)
            {
                // Log
                string @logData = @absence.GetType().Name
                    + " with Date "
                    + @absence.Date
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(@absence.GetType().Name
                    + " with Date "
                    + @absence.Date
                    + " does not exist");
            }

            return @absence;
        }

        /// <summary>
        /// Finds Calendar Days By Filter
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="FilterCalendar"/></param>
        /// <returns>Instance of <see cref="Task{ICollection{ViewDay}}"/></returns>
        public async Task<ICollection<ViewDay>> FindCalendarDaysByFilter(FilterCalendar @viewmodel)
        {
            ICollection<ViewDay> @days = new Collection<ViewDay>();

            for (int i = 1; i <= DateTime.DaysInMonth(viewmodel.Year, viewmodel.Month); i++)
            {
                @days.Add(new ViewDay
                {
                    Date = new DateTime(viewmodel.Year, viewmodel.Month, i),
                    Absence = Mapper.Map<ViewAbsence>(await FindAbsenceByDate(new DateTime(@viewmodel.Year, @viewmodel.Month, i), @viewmodel.ApplicationUserId))
                });
            }

            return @days;
        }        
    }
}
