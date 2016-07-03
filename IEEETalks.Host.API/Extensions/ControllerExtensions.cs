using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace IEEETalks.Host.API
{
    public static class ControllerExtensions
    {
        public static void ThrowValidationException(this ApiController controller, ValidationResult validationResult)
        {
            var jsonString = JsonConvert.SerializeObject(validationResult);
            var responseMsg = new HttpResponseMessage(HttpStatusCode.Conflict)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            throw new HttpResponseException(responseMsg);
        }
    }
}