
using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="AbsenceController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/absence")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IAbsenceService"/>
        /// </summary>
        private readonly IAbsenceService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="AbsenceController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IAbsenceService"/></param>
        public AbsenceController(IAbsenceService service) => Service = service;

        /// <summary>
        /// Adds Absence
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addabsence")]
        public async Task<IActionResult> AddAbsence([FromBody] AddAbsence @viewModel) => new JsonResult(value: await Service.AddAbsence(@viewModel));

        /// <summary>
        /// Removes Absence ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeabsencetbyid/{id}")]
        public async Task<IActionResult> RemoveAbsencetById(int @id)
        {
            await Service.RemoveAbsencetById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }

        /// <summary>
        /// Finds All Absence
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallabsence")]
        public async Task<IActionResult> FindAllAbsence() => new JsonResult(value: await Service.FindAllAbsence());

        /// <summary>
        /// Finds All Absence By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallabsencebyapplicationuserid/{id}")]
        public async Task<IActionResult> FindAllAbsencetByApplicationUserId(int @id) => new JsonResult(value: await Service.FindAllAbsenceByApplicationUserId(@id));
    }
}
