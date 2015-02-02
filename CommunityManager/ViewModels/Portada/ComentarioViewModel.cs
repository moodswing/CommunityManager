using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityManager.ViewModels.Portada
{
    public class ComentarioViewModel : BaseViewModel, IComentarioViewmodel
    {
        public string Nombreusuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
    }

    public interface IComentarioViewmodel
    {
        string Nombreusuario { get; set; }
        DateTime Fecha { get; set; }
        string Texto { get; set; }
    }
}