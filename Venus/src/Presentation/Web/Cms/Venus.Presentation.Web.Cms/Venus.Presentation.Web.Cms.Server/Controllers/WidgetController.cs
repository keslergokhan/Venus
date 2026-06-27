using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Features.Cms.Queries;
using Venus.Core.Application.Features.Cms.Widgets.Commands;
using Venus.Core.Application.Results.Extensions;
using Venus.Core.Application.Services;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;
using Venus.Presentation.Web.Cms.Server.Extensions;
using Venus.Presentation.Web.Cms.Server.Models.Widgets;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : CmsApiControllerBase
    {
        [HttpGet("get-all")]
        public async Task<IActionResult> GetWidgets(CancellationToken cancellationToken)
        {
            var getBlogsResult = await base.Mediator.Send(new GetWidgetsQueriy(), cancellationToken);
            return getBlogsResult.ToActionResult(this);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateWidget([FromBody] UpdateWidgetReq req, CancellationToken cancellationToken)
        {
            var updateResult = await base.Mediator.Send(new UpdateWidgetCommand()
            {
                Id = req.Id ?? default(Guid),
                Template = req.Template
            },cancellationToken);

            return updateResult.ToActionResult(this);
        }

        [HttpGet("bu-bir-deneme")]
        public async Task<IActionResult> Test()
        {
            HtmlTemplateEngineService ss = new HtmlTemplateEngineService();

            await ss.HtmlTemplateSchemaExtractAsync("");

            return Ok();
        }
    }
}
