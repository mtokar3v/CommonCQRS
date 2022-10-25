using FluentValidation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Data.Entity.Core;
using System.Net;

namespace WebApi.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Probably will have to expand to multiple dispatch in the future
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException ex:
                    ReturnBadRequest(context, ex); return;
                case ObjectNotFoundException ex:
                    ReturnNotFoundError(context, ex); return;
                default:
                    ReturnInternalServerError(context); return;
            }
        }

        private void ReturnBadRequest(ExceptionContext context, ValidationException exception)
        {
            context.Result = new BadRequestObjectResult(string.Join(Environment.NewLine, exception.Errors));
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        private void ReturnNotFoundError(ExceptionContext context, Exception exception)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(exception.Message);
        }

        private void ReturnInternalServerError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
