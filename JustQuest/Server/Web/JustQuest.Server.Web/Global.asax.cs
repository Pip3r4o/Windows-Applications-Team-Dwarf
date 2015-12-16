namespace JustQuest.Server.Web
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Routing;
    using App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
