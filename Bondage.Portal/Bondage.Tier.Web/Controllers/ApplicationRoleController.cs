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
    /// Represents a <see cref="ApplicationRoleController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/applicationrole")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ApplicationRoleController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IApplicationRoleService"/>
        /// </summary>
        private readonly IApplicationRoleService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationRoleController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IApplicationRoleService"/></param>
        public ApplicationRoleController(IApplicationRoleService @service) => Service = @service;

        /// <summary>
        /// Updates Application Role
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateApplicationRole"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateapplicationrole")]
        public async Task<IActionResult> UpdateApplicationRole([FromBody]UpdateApplicationRole @viewModel) => new JsonResult(value: await Service.UpdateApplicationRole(@viewModel));

        /// <summary>
        /// Finds All Application Role
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallapplicationrole")]
        public async Task<IActionResult> FindAllApplicationRole() => new JsonResult(value: await Service.FindAllApplicationRole());

        /// <summary>
        /// Adds Application Role
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddApplicationRole"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addapplicationrole")]
        public async Task<IActionResult> AddApplicationRole([FromBody]AddApplicationRole @viewModel) => new JsonResult(value: await Service.AddApplicationRole(@viewModel));

        /// <summary>
        /// Removes Application Role By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeapplicationrolebyid/{id}")]
        public async Task<IActionResult> RemoveApplicationRoleById(int @id)
        {
            await Service.RemoveApplicationRoleById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
