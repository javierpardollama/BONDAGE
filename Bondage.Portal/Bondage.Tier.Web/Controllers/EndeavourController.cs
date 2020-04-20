using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/endeavour")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class EndeavourController : ControllerBase
    {
        private readonly IEndeavourService Service;

        public EndeavourController(IEndeavourService service) => Service = service;

        [HttpGet]
        [Route("findallendeavour")]
        public async Task<IActionResult> FindAllEndeavour() => new JsonResult(value: await Service.FindAllEndeavour());

        [HttpGet]
        [Route("findallendeavourbyapplicationuserbyid/{id}")]
        public async Task<IActionResult> FindAllEndeavourByApplicationUserById(int id) => new JsonResult(value: await Service.FindAllEndeavourByApplicationUserById(id));

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> Start([FromBody]AddEndeavour viewModel) => new JsonResult(value: await Service.Start(viewModel));

        [HttpPost]
        [Route("pause")]
        public async Task<IActionResult> Pause([FromBody]AddEndeavour viewModel) => new JsonResult(value: await Service.Pause(viewModel));

        [HttpPost]
        [Route("resume")]
        public async Task<IActionResult> Resume([FromBody]AddEndeavour viewModel) => new JsonResult(value: await Service.Resume(viewModel));

        [HttpPost]
        [Route("stop")]
        public async Task<IActionResult> Stop([FromBody]AddEndeavour viewModel) => new JsonResult(value: await Service.Stop(viewModel));

        [HttpDelete]
        [Route("removeendeavourbyid/{id}")]
        public async Task<IActionResult> RemoveEndeavourById(int id)
        {
            await Service.RemoveEndeavourById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}