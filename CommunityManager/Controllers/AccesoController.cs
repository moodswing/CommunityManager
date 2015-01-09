using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityManager.Services;
using CommunityManager.ViewModels.Acceso;
using Microsoft.Practices.Unity;
using WebMatrix.WebData;

namespace CommunityManager.Controllers
{
    public class AccesoController : Controller
    {
        #region >>> Dependencias

        [Dependency]
        public IAccesoViewModel ViewModel { get; set; }

        #endregion

        //
        // GET: /Acceso/
        public ActionResult Acceso()
        {
            if (!WebSecurity.Initialized)
                WebSecurity.InitializeDatabaseConnection("CommunityContext", "Usuarios", "Id", "Email", autoCreateTables: true);

            return View();
        }

        [HttpPost]
        public ActionResult Autentificar(AccesoViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var success = WebSecurity.Login(usuario.Email, usuario.Password, usuario.Recordarme);
                if (success) return Json(new { result = "Redirect", url = Url.Action("Portada", "Inicio") });

                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return PartialView("Partial/_LoginBox", new AccesoViewModel());
            }

            return Json(new { result = "Redirect", url = Url.Action("Acceso", "Acceso") });
        }
	}
}