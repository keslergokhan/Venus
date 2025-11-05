using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Venus.Presentation.Web.Cms.Server.Controllers.Base
{
    public abstract class CmsApiControllerBase : ControllerBase
    {
        protected IMediator Mediator
        {
            get
            {
                return HttpContext.RequestServices.GetRequiredService<IMediator>(); 
            }
        }
    }
}
