using System.Threading.Tasks;
using Bondage.Tier.Services.Interfaces;
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

        [HttpDelete]
        [Route("removeficherobyid/{id}")]
        public async Task<IActionResult> RemoveFicheroById(int id)
        {
            await Service.RemoveFicheroById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
