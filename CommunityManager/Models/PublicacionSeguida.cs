using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommunityManager.Models
{
    [Table("PublicacionesSeguidas")]
    public class PublicacionSeguida
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Fecha { get; set; }

        public int UsuarioID { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuario Usuario { get; set; }

        public int PublicacionID { get; set; }
        [ForeignKey("PublicacionID")]
        public virtual Publicacion Publicacion { get; set; }
    }
}