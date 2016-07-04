using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FluentValidation.Results;
using IEEETalks.CQS.Infrastructure.CommandProcessor;
using Newtonsoft.Json;

namespace IEEETalks.Host.API
{
    public static class ControllerValidationExtensions
    {
        public static void ThrowValidationException(ValidationResult validationResult)
        {
            var jsonString = JsonConvert.SerializeObject(validationResult);
            var responseMsg = new HttpResponseMessage(HttpStatusCode.Conflict)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            throw new HttpResponseException(responseMsg);
        }

        public static void ValidateNull(this ApiController controller, object objValidation, string message)
        {
            if (objValidation == null)
            {
                var failure = new ValidationFailure("Generic", message);

                var validationResult = new ValidationResult(new List<ValidationFailure>() { failure });

                ThrowValidationException(validationResult);
            }
        }

        public static void ValidateCommandResult(this ApiController controller, ICommandResult commandResult)
        {
            if (!commandResult.Success)
            {
                ThrowValidationException(commandResult.ValidationResult);
            }
        }
    }
}