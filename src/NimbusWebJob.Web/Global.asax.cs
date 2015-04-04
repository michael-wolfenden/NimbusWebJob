using System;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Serilog;

namespace NimbusWebJob.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Logging.Configure();
            IoC.Configure();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(IoC.Container));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Log.Logger.Fatal(exception, "An Unhandled exception was thrown");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            IoC.Shutdown();
        }
    }
}
