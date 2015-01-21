using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityManager.Models;

namespace CommunityManager.ViewModels.Acceso
{
    public class AccesoViewModel : BaseViewModel, IAccesoViewModel
    {
        [Required(ErrorMessage = "Ingrese nombre de usuario")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "No cerrar sesi�n")]
        public bool Recordarme { get; set; }
    }

    public interface IAccesoViewModel
    {
        string Email { get; set; }
        string Password { get; set; }
        bool Recordarme { get; set; }
    }
}