using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Authentications.Queries;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Models.Authentications;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : CmsApiControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]AuthenticationLoginReq req)
        {
            var result = await base.Mediator.Send(new VenusAuthenticationQuery()
            {
                Email = req.Email,
                Password = req.Password,
            });


            return Ok(result.Data);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok("başarılı");
        }
    }
}
