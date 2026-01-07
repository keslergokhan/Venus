using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Authentications.Queries;
using Venus.Core.Application.Results.Extensions;
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


            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = "Kullanıcı bulunamadı." }); 
            }

            return result.ToActionResult(this);
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Validate()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var authHeader))
                return Unauthorized(new { message = "Kullanıcı bulunamadı." });

            var result = await base.Mediator.Send(new VenusAuthenticationValidateQuery()
            {
                JwtToken = authHeader.ToString().Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase)
            });

            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = "Kullanıcı bulunamadı." });
            }

            return result.ToActionResult(this);
        }
    }
}
