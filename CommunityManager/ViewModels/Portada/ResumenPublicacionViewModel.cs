using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityManager.Models;

namespace CommunityManager.ViewModels.Portada
{
    public class ResumenPublicacionViewModel : BaseViewModel, IResumenPublicacionViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public TipoPublicacion TipoPublicacion { get; set; }
    }

    public interface IResumenPublicacionViewModel
    {
        int Id { get; set; }
        string Titulo { get; set; }
        DateTime FechaIngreso { get; set; }
        TipoPublicacion TipoPublicacion { get; set; }
    }
}