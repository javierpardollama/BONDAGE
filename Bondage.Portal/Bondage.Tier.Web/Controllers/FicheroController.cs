using System.Threading.Tasks;
using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Additions;
using Bondage.Tier.ViewModels.Classes.Updates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/fichero")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class FicheroController : ControllerBase
    {
        private readonly IFicheroService Service;

        public FicheroController(IFicheroService service) => Service = service;

        [HttpGet]
        [Route("findallficherobyapplicationuserid/{id}")]
        public async Task<IActionResult> FindAllFicheroByApplicationUserId(int id) => new JsonResult(value: await Service.FindAllFicheroByApplicationUserId(id));

        [HttpGet]
        [Route("findallfichero")]
        public async Task<IActionResult> FindAllFichero() => new JsonResult(value: await Service.FindAllFichero());

        [HttpPost]
        [Route("addfichero")]
        public async Task<IActionResult> AddFichero([FromBody]AddFichero viewModel) => new JsonResult(value: await Service.AddFichero(viewModel));


        [HttpPut]
        [Route("updatefichero")]
        public async Task<IActionResult> UpdateBandera([FromBody]UpdateFichero viewModel) => new JsonResult(value: await Service.UpdateFichero(viewModel));

        [HttpDelete]
        [Route("removeficherobyid/{id}")]
        public async Task<IActionResult> RemoveFicheroById(int id)
        {
            await Service.RemoveFicheroById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
