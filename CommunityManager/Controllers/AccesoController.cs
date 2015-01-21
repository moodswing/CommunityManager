using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
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

            AccesoViewModel.Recordarme = true;
            AccesoViewModel.Email = "rob.arav@gmail.com";

            return View(AccesoViewModel);
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
                    {
                        IngresoDatosViewModel.UserName = usuario.Email;
                        IngresoDatosViewModel.NumeroVivienda = "1706";
                        IngresoDatosViewModel.Nombre = "Robinson";
                        IngresoDatosViewModel.Apellido = "Aravena";
                        IngresoDatosViewModel.NombreUsuario = "Robinson Aravena";

                        return PartialView("Partial/_Configuration", IngresoDatosViewModel);
                    }

                    return Json(new { result = "Redirect", url = Url.Action("Inicio", "Portada") });
                }

                ModelState.AddModelError("", "Correo o contraseña incorrectos");
                return PartialView("Partial/_LoginBox", AccesoViewModel);
            }

            return Json(new { result = "Redirect", url = Url.Action("Index", "Error") });
        }

        [HttpPost]
        public ActionResult IngresarDatos(IngresoDatosViewModel datos)
        {
            if (ModelState.IsValid)
            {
                var user = UsuarioService.ObtenerPorId(WebSecurity.GetUserId(datos.UserName));
                if (user.NumeroVivienda == datos.NumeroVivienda)
                {
                    WebSecurity.ChangePassword(datos.UserName, "12345", datos.Password);
                    user.EstadoUsuario = EstadoUsuario.Activo;
                    UsuarioService.Actualizar(user, datos);
                    return Json(new { result = "Redirect", url = Url.Action("Inicio", "Portada") });
                }
                
                ModelState.AddModelError("NumeroVivienda", "El número de vivienda ingresado es incorrecto");
                return PartialView("Partial/_Configuration", datos);
            }

            return Json(new { result = "Redirect", url = Url.Action("Index", "Error") });
        }
    }
}