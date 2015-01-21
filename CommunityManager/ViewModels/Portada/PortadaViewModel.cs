using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityManager.Models;

namespace CommunityManager.ViewModels.Portada
{
    public class PortadaViewModel : BaseViewModel, IPortadaViewModel
    {
        public string TituloPagina { get; set; }
        public List<IResumenPublicacionViewModel> Publicaciones { get; set; }

        public PortadaViewModel()
        {
            Publicaciones = new List<IResumenPublicacionViewModel>();
        }
    }

    public interface IPortadaViewModel
    {
        string TituloPagina { get; set; }
        TipoPublicacion FiltrarPublicacionesPor { get; set; }
        List<IResumenPublicacionViewModel> Publicaciones { get; set; }
    }
}