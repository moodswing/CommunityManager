using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using CommunityManager.App_Start;
using Microsoft.Practices.Unity;

namespace CommunityManager.Infrastructure
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