using System.Web;
using System.Web.Http;

namespace IEEETalks.Host.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependencyConfig.RegisterAll();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
