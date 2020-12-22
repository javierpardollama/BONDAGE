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
    /// Represents a <see cref="GradeController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/grade")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class GradeController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IGradeService"/>
        /// </summary>
        private readonly IGradeService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="GradeController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IGradeService"/></param>
        public GradeController(IGradeService service) => Service = service;

        /// <summary>
        /// Updates Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateGrade"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updategrade")]
        public async Task<IActionResult> UpdateGrade([FromBody] UpdateGrade @viewModel) => new JsonResult(value: await Service.UpdateGrade(@viewModel));

        /// <summary>
        /// Finds All Grade
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallgrade")]
        public async Task<IActionResult> FindAllGrade() => new JsonResult(value: await Service.FindAllGrade());

        /// <summary>
        /// Adds Grade
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddGrade"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addgrade")]
        public async Task<IActionResult> AddGrade([FromBody] AddGrade @viewModel) => new JsonResult(value: await Service.AddGrade(@viewModel));

        /// <summary>
        /// Removes Grade ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removegradebyid/{id}")]
        public async Task<IActionResult> RemoveGradeById(int @id)
        {
            await Service.RemoveGradeById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
