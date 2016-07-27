using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using FluentValidation;
using Newtonsoft.Json;

namespace IEEETalks.Host.API.Filters
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception as ValidationException;

            if (exception != null)
            {
                var jsonString = JsonConvert.SerializeObject(exception.Errors);
                var responseMsg = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                context.Response = responseMsg;
            }
            else
            {
                var jsonString = JsonConvert.SerializeObject(new { Message = context.Exception.Message });
                var responseMsg = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                context.Response = responseMsg;
            }
        }
    }
}