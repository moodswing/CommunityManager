using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommunityManager.Models
{
    [Table("Comentarios")]
    public class Comentario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int PublicacionId { get; set; }
        public virtual Publicacion Publicacion { get; set; }
    }
}