using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Middlewares
{
    public class CustomResultFilterMiddleware : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executed = await next();

            // Action bir ObjectResult döndürmüş mü?
            if (executed.Result is ObjectResult result && result.Value != null)
            {
                if (result.Value is IResultControl)
                {
                    var response = result.Value as IResultControl;
                    // Response tipi MyResponse mı?
                    if (!response.IsSuccess)
                    {
                        result.StatusCode = 400;
                    }
                }
            }
        }
    }
}
