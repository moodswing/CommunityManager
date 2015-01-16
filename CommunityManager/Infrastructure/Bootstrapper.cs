using AutoMapper;
using CommunityManager.DataAccessLayer;
using CommunityManager.Infrastructure.MappingProfiles;
using CommunityManager.Services;
using CommunityManager.ViewModels.Acceso;
using Microsoft.Practices.Unity;

namespace CommunityManager.Infrastructure
{
    public static class Bootstrapper
    {
        public static IUnityContainer ConfigureUnityContainer()
        {
            var container = GetUnityContainer();

            return container;
        }

        private static IUnityContainer GetUnityContainer()
        {
            var container = new UnityContainer()
                .RegisterType<IUsuarioService, UsuarioService>()
                .RegisterType<IAccesoViewModel, AccesoViewModel>()
                .RegisterType<IIngresoDatosViewModel, IngresoDatosViewModel>()
                .RegisterType<CommunityContext>(new HierarchicalLifetimeManager());

            return container;
        }

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                x.AddProfile(new AccesoMappingProfiles()));
        }
    }
}