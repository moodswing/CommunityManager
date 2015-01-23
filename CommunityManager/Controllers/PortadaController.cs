using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CommunityManager.Models;
using CommunityManager.Services;
using CommunityManager.ViewModels.Acceso;
using CommunityManager.ViewModels.Portada;
using Microsoft.Practices.Unity;
using WebMatrix.WebData;

namespace CommunityManager.Controllers
{
    public class PortadaController : Controller
    {
        #region >>> Dependencias

        [Dependency]
        public IPortadaViewModel PortadaViewModel { get; set; }
        [Dependency]
        public IPublicacionViewModel PublicacionViewModel { get; set; }
        [Dependency]
        public IPublicacionService PublicacionService { get; set; }

        #endregion

        //
        // GET: /Portada/
        public ActionResult Inicio()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            PortadaViewModel.Publicaciones = PublicacionService.ListaResumen();
            PortadaViewModel.PublicacionInicial = PublicacionService.PublicacionCompleta(PortadaViewModel.Publicaciones.FirstOrDefault());
            PortadaViewModel.TituloPagina = "Publicaciones recientes";
            PortadaViewModel.FiltrarPublicacionesPor = TipoPublicacion.Todo;
            
            return View(PortadaViewModel);
        }

        [HttpGet]
        public ActionResult PublicacionesPorTipo(int tipo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            PortadaViewModel.FiltrarPublicacionesPor = (TipoPublicacion)tipo;

            switch (PortadaViewModel.FiltrarPublicacionesPor)
            {
                case TipoPublicacion.Todo:
                    PortadaViewModel.TituloPagina = "Publicaciones recientes";
                    PortadaViewModel.Publicaciones = PublicacionService.ListaResumen();
                    break;
                case TipoPublicacion.Vista:
                    PortadaViewModel.TituloPagina = "Publicaciones vistas recientemente";
                    PortadaViewModel.Publicaciones = PublicacionService.ListaResumenVistasRecientes(WebSecurity.CurrentUserId);
                    break;
                case TipoPublicacion.Siguiendo:
                    PortadaViewModel.TituloPagina = "Publicaciones que sigues";
                    PortadaViewModel.Publicaciones = PublicacionService.ListaResumenSeguidas(WebSecurity.CurrentUserId);
                    break;
                case TipoPublicacion.Administracion:
                    PortadaViewModel.TituloPagina = "Publicaciones de la administración";
                    PortadaViewModel.Publicaciones = new List<IResumenPublicacionViewModel>();
                    break;
                case TipoPublicacion.Cuenta:
                    PortadaViewModel.Publicaciones = new List<IResumenPublicacionViewModel>();
                    break;
                default:
                    PortadaViewModel.TituloPagina = "Publicaciones de " + PortadaViewModel.FiltrarPublicacionesPor.ToString();
                    PortadaViewModel.Publicaciones = PublicacionService.ResumenPorTipo(PortadaViewModel.FiltrarPublicacionesPor);
                    break;
            }

            PortadaViewModel.PublicacionInicial = PublicacionService.PublicacionCompleta(PortadaViewModel.Publicaciones.FirstOrDefault());
            return View("Inicio", PortadaViewModel);
        }

        [HttpPost]
        public ActionResult CargarPublicacion(int id)
        {
            var publicacionVm = PublicacionService.PublicacionCompleta(id);
            return PartialView("Partial/_Publicacion", publicacionVm);
        }
    }
}