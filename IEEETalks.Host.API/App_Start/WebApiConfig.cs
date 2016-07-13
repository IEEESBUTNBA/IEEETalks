using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using IEEETalks.Host.API.Filters;
using Newtonsoft.Json.Serialization;

namespace IEEETalks.Host.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ** NOT WORKING WITH SWAGGER **
            //var jsonFormatter = new JsonMediaTypeFormatter
            //{
            //    SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            //};
            //config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            // ** NOT WORKING WITH SWAGGER **

            // Filter exceptions configuration
            config.Filters.Add(new ExceptionHandlerFilterAttribute());

            // Web API configuration and services
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
