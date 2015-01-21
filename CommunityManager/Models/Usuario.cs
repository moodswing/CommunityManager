using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CommunityManager.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Email { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string NumeroVivienda { get; set; }

        public virtual ICollection<Publicacion> Publicaciones { get; set; }
        //public virtual ICollection<PublicacionVista> PublicacionesVistas { get; set; }

        public EstadoUsuario EstadoUsuario { get; set; }
    }

    public enum EstadoUsuario
    {
        Activo,
        Inactivo
    }
}