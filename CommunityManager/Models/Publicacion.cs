using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommunityManager.Models
{
    [Table("Publicaciones")]
    public class Publicacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
        public int VotosPositivos { get; set; }
        public int VotosNegativos { get; set; }
        public int Precio { get; set; }

        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }

        public TipoPublicacion TipoPublicacion { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }

    public enum TipoPublicacion
    {
        Encuesta,
        Reclamo,
        Propuesta,
        Servicio,
        Venta,
        Regalo,
        Vista,
        Siguiendo,
        Administracion,
        Cuenta,
        Todo
    }
}