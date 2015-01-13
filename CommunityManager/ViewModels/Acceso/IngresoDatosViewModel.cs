using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityManager.ViewModels.Acceso
{
    public class IngresoDatosViewModel : IIngresoDatosViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [Display(Description = "Siempre que publiques algo este será el nombre que se muestre")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres de largo.", MinimumLength = 6)]
        [Display(Description = "Elige un nuevo password para tu cuenta")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarPassword { get; set; }

        [Required]
        [Display(Description = "Para evitar filtraciones o suplantaciones debes validar que tu correo está asignado al número de vivienda correcto")]
        public string NumeroVivienda { get; set; }
    }

    public interface IIngresoDatosViewModel
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        string NombreUsuario { get; set; }
        string Password { get; set; }
        string ConfirmarPassword { get; set; }
        string NumeroVivienda { get; set; }
    }
}