using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ApplicationUserController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/applicationuser")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IApplicationUserService"/>
        /// </summary>
        private readonly IApplicationUserService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationUserController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IApplicationUserService"/></param>
        public ApplicationUserController(IApplicationUserService @service) => Service = @service;

        /// <summary>
        /// Updates Application User
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateApplicationUser"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateapplicationuser")]
        public async Task<IActionResult> UpdateApplicationUser([FromBody]UpdateApplicationUser @viewModel) => new JsonResult(value: await Service.UpdateApplicationUser(@viewModel));

        /// <summary>
        /// Finds All Application User
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallapplicationuser")]
        public async Task<IActionResult> FindAllApplicationUser() => new JsonResult(value: await Service.FindAllApplicationUser());

        /// <summary>
        /// Removes Application User By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeapplicationuserbyid/{id}")]
        public async Task<IActionResult> RemoveApplicationUserById(int @id)
        {
            await Service.RemoveApplicationUserById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
