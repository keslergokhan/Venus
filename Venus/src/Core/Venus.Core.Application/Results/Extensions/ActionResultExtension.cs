using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Results.Extensions
{
    public static class ActionResultExtension
    {
        public static IActionResult ToActionResult(this IResultControl result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                return controller.Ok();
            }
            else
            {
                if (result.Exception is VenusExceptionBase)
                {
                    return controller.BadRequest(new
                    {
                        errorMessage = result.ErrorMessage,
                        errorCode = result.ErrorCode
                    });
                }

            }

            return controller.BadRequest(new
            {
                errorMessage = result.ErrorMessage,
                errorCode = result.ErrorCode
            });
        }

        public static IActionResult ToActionResult<T>(this IResultDataControl<T> result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                return controller.Ok(result.Data);
            }
            else
            {
                if (result.Exception is VenusExceptionBase)
                {
                    return controller.BadRequest(new
                    {
                        errorMessage = result.ErrorMessage,
                        errorCode = result.ErrorCode
                    });
                }
                
            }

            return controller.BadRequest(new
            {
                errorMessage = result.ErrorMessage,
                errorCode = result.ErrorCode
            });
        }
    }
}
