﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bondage.Tier.Entities.Classes;
using Bondage.Tier.ViewModels.Classes.Filters;
using Bondage.Tier.ViewModels.Classes.Views;

namespace Bondage.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="ICalendarService"/> interface. Inherits <see cref="IBaseService"/>.
    /// </summary>
    public interface ICalendarService : IBaseService
    {
        /// <summary>
        /// Finds Absence By Date
        /// </summary>
        /// <param name="date">Injected <see cref="DateTime"/></param>
        /// <returns>Instance of <see cref="Task{Effort}"/></returns>
        Task<Absence> FindAbsenceByDate(DateTime @date);

        /// <summary>
        /// Finds Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{ApplicationUser}"/></returns>
        Task<ApplicationUser> FindApplicationUserById(int @id);

        /// <summary>
        /// Finds Calendar Days By Filter
        /// </summary>
        /// <param name="viewmodel">Injected <see cref="FilterCalendar"/></param>
        /// <returns>Instance of <see cref="Task{ICollection{ViewDay}}"/></returns>
        Task<ICollection<ViewDay>> FindCalendarDaysByFilter(FilterCalendar @viewmodel);
    }
}
