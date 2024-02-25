using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RiotApiController.Domain.Entities.Commons;
using RiotSharp;
using System.Net;
using System.Text.Json;

namespace RiotApiController.Domain.Entities
{
    public class RiotApiResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is RiotSharpException riotSharpException)
            {
                var riotApiErrorResponseBody = new RiotApiErrorResponseBody(riotSharpException);
                context.Result = new ObjectResult(JsonSerializer.Serialize(riotApiErrorResponseBody))
                {
                    StatusCode = (int)riotSharpException.HttpStatusCode
                };

                context.ExceptionHandled = true;
            }
            else if (context.Exception != null)
            {
                var elseException = new RiotSharpException(context.Exception.Message, HttpStatusCode.InternalServerError);

                var riotApiErrorResponseBody = new RiotApiErrorResponseBody(elseException);
                context.Result = new ObjectResult(JsonSerializer.Serialize(riotApiErrorResponseBody))
                {
                    StatusCode = (int)elseException.HttpStatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
