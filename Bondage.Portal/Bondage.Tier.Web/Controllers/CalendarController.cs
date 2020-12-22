
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Filters;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="CalendarController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/calendar")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="ICalendarService"/>
        /// </summary>
        private readonly ICalendarService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="CalendarController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="ICalendarService"/></param>
        public CalendarController(ICalendarService service) => Service = service;

        /// <summary>
        /// Finds Calendar Days By Filter
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterCalendar"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findcalendardaysbyfilter")]
        public async Task<IActionResult> FindCalendarDaysByFilter([FromBody] FilterCalendar @viewModel) => new JsonResult(value: await Service.FindCalendarDaysByFilter(@viewModel));
    }
}
