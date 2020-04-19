using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/security")]
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

        [HttpPut]
        [Route("finish")]
        public async Task<IActionResult> Finish([FromBody]UpdateEndeavour viewModel) => new JsonResult(value: await Service.Finish(viewModel));


        [HttpDelete]
        [Route("removeendeavourbyid/{id}")]
        public async Task<IActionResult> RemoveEndeavourById(int id)
        {
            await Service.RemoveEndeavourById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}