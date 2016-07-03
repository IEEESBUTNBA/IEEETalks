using System.Web;
using System.Web.Http;

namespace IEEETalks.Host.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependenciesConfig.RegisterAll();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
