using System.Net;
using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/archive")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IArchiveService Service;

        public ArchiveController(IArchiveService service) => Service = service;

        [HttpGet]
        [Route("findallarchivebyapplicationuserid/{id}")]
        public async Task<IActionResult> FindAllArchiveByApplicationUserId(int id) => new JsonResult(value: await Service.FindAllArchiveByApplicationUserId(id));

        [HttpGet]
        [Route("findallsharedarchivebyapplicationuserid/{id}")]
        public async Task<IActionResult> FindAllSharedArchiveByApplicationUserId(int id) => new JsonResult(value: await Service.FindAllSharedArchiveByApplicationUserId(id));

        [HttpGet]
        [Route("findallarchive")]
        public async Task<IActionResult> FindAllArchive() => new JsonResult(value: await Service.FindAllArchive());

        [HttpPost]
        [Route("addarchive")]
        public async Task<IActionResult> AddArchive([FromBody]AddArchive viewModel) => new JsonResult(value: await Service.AddArchive(viewModel));

        [HttpPut]
        [Route("updatearchive")]
        public async Task<IActionResult> UpdateArchive([FromBody]UpdateArchive viewModel) => new JsonResult(value: await Service.UpdateArchive(viewModel));

        [HttpDelete]
        [Route("removearchivebyid/{id}")]
        public async Task<IActionResult> RemoveArchiveById(int id)
        {
            await Service.RemoveArchiveById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
