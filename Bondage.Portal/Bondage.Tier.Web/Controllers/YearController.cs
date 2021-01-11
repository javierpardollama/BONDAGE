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
    /// Represents a <see cref="YearController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/year")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class YearController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IYearService"/>
        /// </summary>
        private readonly IYearService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="YearController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IYearService"/></param>
        public YearController(IYearService service) => Service = service;

        /// <summary>
        /// Updates Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateYear"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateyear")]
        public async Task<IActionResult> UpdateYear([FromBody] UpdateYear @viewModel) => new JsonResult(value: await Service.UpdateYear(@viewModel));

        /// <summary>
        /// Finds All Year
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallyear")]
        public async Task<IActionResult> FindAllYear() => new JsonResult(value: await Service.FindAllYear());

        /// <summary>
        /// Adds Year
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddYear"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addyear")]
        public async Task<IActionResult> AddYear([FromBody] AddYear @viewModel) => new JsonResult(value: await Service.AddYear(@viewModel));

        /// <summary>
        /// Removes Year ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeyearbyid/{id}")]
        public async Task<IActionResult> RemoveYearById(int @id)
        {
            await Service.RemoveYearById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
