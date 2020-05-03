using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="EffortController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/effort")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class EffortController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IEffortService"/>
        /// </summary>
        private readonly IEffortService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="EffortController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IEffortService"/></param>
        public EffortController(IEffortService service) => Service = service;

        /// <summary>
        /// Finds All Effort
        /// </summary>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpGet]
        [Route("findalleffort")]
        public async Task<IActionResult> FindAllEffort() => new JsonResult(value: await Service.FindAllEffort());

        /// <summary>
        /// Finds All Effort By Application User Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns></returns>
        [HttpGet]
        [Route("findalleffortbyapplicationuserbyid/{id}")]
        public async Task<IActionResult> FindAllEffortByApplicationUserById(int @id) => new JsonResult(value: await Service.FindAllEffortByApplicationUserById(@id));

        /// <summary>
        /// Starts
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBreak"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> Start([FromBody]AddBreak @viewModel) => new JsonResult(value: await Service.Start(@viewModel));

        /// <summary>
        /// Pauses
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBreak"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("pause")]
        public async Task<IActionResult> Pause([FromBody]AddBreak @viewModel) => new JsonResult(value: await Service.Pause(@viewModel));

        /// <summary>
        /// Resumes
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBreak"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("resume")]
        public async Task<IActionResult> Resume([FromBody]AddBreak @viewModel) => new JsonResult(value: await Service.Resume(@viewModel));

        /// <summary>
        /// Stops
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBreak"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("stop")]
        public async Task<IActionResult> Stop([FromBody]AddBreak @viewModel) => new JsonResult(value: await Service.Stop(@viewModel));

        /// <summary>
        /// Removes Effort By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpDelete]
        [Route("removeeffortbyid/{id}")]
        public async Task<IActionResult> RemoveEffortById(int @id)
        {
            await Service.RemoveEffortById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}