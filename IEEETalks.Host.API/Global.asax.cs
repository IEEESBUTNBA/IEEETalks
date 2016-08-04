using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Http;
using IEEETalks.Common;

namespace IEEETalks.Host.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            FluentValidation.Resources.Messages.Culture = CultureInfo.GetCultureInfo("en-US");

            GlobalConfiguration.Configure(config =>
            {
                IApplicationSettings applicationSettings;
                DependenciesConfig.Register(config, out applicationSettings);
                WebApiConfig.Register(config, applicationSettings);
            });
        }
    }
}
