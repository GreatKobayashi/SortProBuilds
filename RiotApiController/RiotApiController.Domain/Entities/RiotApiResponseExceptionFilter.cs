using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RiotApiController.Domain.Entities.Commons;
using RiotSharp;
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
        }
    }
}
