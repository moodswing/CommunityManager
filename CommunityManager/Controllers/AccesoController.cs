using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityManager.Services;
using CommunityManager.ViewModels.Acceso;
using Microsoft.Practices.Unity;

namespace CommunityManager.Controllers
{
    public class AccesoController : Controller
    {
        #region >>> Dependencias

        [Dependency]
        public IUsuarioService UsuarioService { get; set; }
        [Dependency]
        public IAccesoViewModel ViewModel { get; set; }

        #endregion

        //
        // GET: /Acceso/
        public ActionResult Acceso()
        {
            ViewModel.Usuarios = UsuarioService.Todos();

            return View(ViewModel);
        }
	}
}