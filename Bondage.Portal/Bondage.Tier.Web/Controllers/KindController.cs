using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="KindController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/kind")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class KindController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IKindService"/>
        /// </summary>
        private readonly IKindService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="KindController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IKindService"/></param>
        public KindController(IKindService service) => Service = service;

        /// <summary>
        /// Updates Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateKind"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updatekind")]
        public async Task<IActionResult> UpdateKind([FromBody] UpdateKind @viewModel) => new JsonResult(value: await Service.UpdateKind(@viewModel));

        /// <summary>
        /// Finds All Kind
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallkind")]
        public async Task<IActionResult> FindAllKind() => new JsonResult(value: await Service.FindAllKind());

        /// <summary>
        /// Adds Kind
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddKind"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addkind")]
        public async Task<IActionResult> AddKind([FromBody] AddKind @viewModel) => new JsonResult(value: await Service.AddKind(@viewModel));

        /// <summary>
        /// Removes Kind ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removekindbyid/{id}")]
        public async Task<IActionResult> RemoveKindById(int @id)
        {
            await Service.RemoveKindById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
