using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityManager.Models;
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
        public IAccesoViewModel AccesoViewModel { get; set; }
        [Dependency]
        public IIngresoDatosViewModel IngresoDatosViewModel { get; set; }
        [Dependency]
        public IUsuarioService UsuarioService { get; set; }

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
                if (success)
                {
                    var user = UsuarioService.ObtenerPorId(WebSecurity.GetUserId(usuario.Email));
                    if (user.EstadoUsuario == EstadoUsuario.Inactivo)
                        return PartialView("Partial/_Configuration", IngresoDatosViewModel);
                        
                    return Json(new { result = "Redirect", url = Url.Action("Portada", "Inicio") });
                }

                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return PartialView("Partial/_LoginBox", AccesoViewModel);
            }

            return Json(new { result = "Redirect", url = Url.Action("Acceso", "Acceso") });
        }



        [HttpPost]
        public ActionResult IngresarDatos(IngresoDatosViewModel datos)
        {
            if (ModelState.IsValid)
            {
            }

            return Json(new { result = "Redirect", url = Url.Action("Acceso", "Acceso") });
        }
    }
}