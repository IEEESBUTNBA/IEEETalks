using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace IEEETalks.Host.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            FluentValidation.Resources.Messages.Culture = CultureInfo.GetCultureInfo("en-US");

            DependenciesConfig.RegisterAll();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
