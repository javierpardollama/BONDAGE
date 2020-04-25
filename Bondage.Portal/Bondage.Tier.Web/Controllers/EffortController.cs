using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/effort")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class EffortController : ControllerBase
    {
        private readonly IEffortService Service;

        public EffortController(IEffortService service) => Service = service;

        [HttpGet]
        [Route("findalleffort")]
        public async Task<IActionResult> FindAllEffort() => new JsonResult(value: await Service.FindAllEffort());

        [HttpGet]
        [Route("findalleffortbyapplicationuserbyid/{id}")]
        public async Task<IActionResult> FindAllEffortByApplicationUserById(int id) => new JsonResult(value: await Service.FindAllEffortByApplicationUserById(id));

        [HttpPost]
        [Route("start")]
        public async Task<IActionResult> Start([FromBody]AddBreak viewModel) => new JsonResult(value: await Service.Start(viewModel));

        [HttpPost]
        [Route("pause")]
        public async Task<IActionResult> Pause([FromBody]AddBreak viewModel) => new JsonResult(value: await Service.Pause(viewModel));

        [HttpPost]
        [Route("resume")]
        public async Task<IActionResult> Resume([FromBody]AddBreak viewModel) => new JsonResult(value: await Service.Resume(viewModel));

        [HttpPost]
        [Route("stop")]
        public async Task<IActionResult> Stop([FromBody]AddBreak viewModel) => new JsonResult(value: await Service.Stop(viewModel));

        [HttpDelete]
        [Route("removeeffortbyid/{id}")]
        public async Task<IActionResult> RemoveEffortById(int id)
        {
            await Service.RemoveEffortById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}