using System.Threading.Tasks;

using Bondage.Tier.Services.Interfaces;
using Bondage.Tier.ViewModels.Classes.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondage.Tier.Web.Controllers
{
    [Route("api/security")]
    [Produces("application/json")]
    public class SecurityController
    {
        private readonly ISecurityService Service;

        public SecurityController(ISecurityService service) => Service = service;

        [HttpPut]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody]SecurityPasswordReset viewModel) => new JsonResult(value: await Service.ResetPassword(viewModel));

        [HttpPut]
        [Route("changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody]SecurityPasswordChange viewModel) => new JsonResult(value: await Service.ChangePassword(viewModel));

        [HttpPut]
        [Route("changeemail")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail([FromBody]SecurityEmailChange viewModel) => new JsonResult(value: await Service.ChangeEmail(viewModel));
    }
}
