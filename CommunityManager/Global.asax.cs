using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommunityManager.App_Start;
using CommunityManager.DataAccessLayer;
using CommunityManager.Infrastructure;
using Microsoft.Practices.Unity;

namespace CommunityManager
{
    public class MvcApplication : HttpApplication
    {
        private static Guid _unityGuid;
        private static IUnityContainer _container;

        protected void Application_Start()
        {
            _unityGuid = Guid.NewGuid();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Database.SetInitializer(new DataInitializer());

            Bootstrapper.RegisterMappings();
            _container = Bootstrapper.ConfigureUnityContainer();
            MvcConfig.Register(_container, _unityGuid);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            var childContainer = _container.CreateChildContainer();
            HttpContext.Current.Items[_unityGuid] = childContainer;
        }

        protected void Application_EndRequest()
        {
            var childContainer = HttpContext.Current.Items[_unityGuid] as IUnityContainer;
            if (childContainer != null)
            {
                childContainer.Dispose();
                HttpContext.Current.Items.Remove(_unityGuid);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            if (ex.Message == "File does not exist.")
            {
                throw new Exception(string.Format("{0} {1}", ex.Message, HttpContext.Current.Request.Url), ex);
            }
        }
    }
}
