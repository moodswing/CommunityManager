using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace CommunityManager.App_Start
{
    public class MvcConfig
    {
        public static void Register(IUnityContainer container, Guid containerGuid)
        {
            container.RegisterInstance(typeof(IControllerActivator), new UnityControllerActivator(containerGuid));

            foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes().
                            Where(x => x.GetInterface(typeof(IController).Name) != null))
            {
                container.RegisterType(type);
            }

            DependencyResolver.SetResolver(
                t => container.IsRegistered(t) ? container.Resolve(t) : null,
                t => container.IsRegistered(t) ? container.ResolveAll(t) : Enumerable.Empty<object>());
        }
    }
}