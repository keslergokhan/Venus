using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venus.Core.Application.Dtos.Systems.Pages;
using Venus.Core.Application.Features.Cms.Pages.Queries;
using Venus.Core.Application.Results.Interfaces;
using Venus.Presentation.Web.Cms.Server.Controllers.Base;

namespace Venus.Presentation.Web.Cms.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PageManagerController : CmsApiControllerBase
    {

        [HttpGet()]
        public async Task<IResultDataControl<List<ReadVenusPageAboutDto>>> GetPageAbouts()
        {
            var pageAboutList = await base.Mediator.Send(new VenusGetPageAboutQuery());

            if (!pageAboutList.IsSuccess)
            {
                throw pageAboutList.Exception;
            }

            return pageAboutList;
        }
    }
}
