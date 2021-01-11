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
    /// Represents a <see cref="MonthController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/month")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class MonthController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IMonthService"/>
        /// </summary>
        private readonly IMonthService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="MonthController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IMonthService"/></param>
        public MonthController(IMonthService service) => Service = service;

        /// <summary>
        /// Updates Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateMonth"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updatemonth")]
        public async Task<IActionResult> UpdateMonth([FromBody] UpdateMonth @viewModel) => new JsonResult(value: await Service.UpdateMonth(@viewModel));

        /// <summary>
        /// Finds All Month
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallmonth")]
        public async Task<IActionResult> FindAllMonth() => new JsonResult(value: await Service.FindAllMonth());

        /// <summary>
        /// Adds Month
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddMonth"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addmonth")]
        public async Task<IActionResult> AddMonth([FromBody] AddMonth @viewModel) => new JsonResult(value: await Service.AddMonth(@viewModel));

        /// <summary>
        /// Removes Month ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removemonthbyid/{id}")]
        public async Task<IActionResult> RemoveMonthById(int @id)
        {
            await Service.RemoveMonthById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
