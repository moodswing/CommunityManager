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
        public int VotosPositivos { get; set; }
        public int VotosNegativos { get; set; }
        public int NumeroComentarios { get; set; }
    }

    public interface IResumenPublicacionViewModel
    {
        int Id { get; set; }
        string Titulo { get; set; }
        DateTime FechaIngreso { get; set; }
        TipoPublicacion TipoPublicacion { get; set; }
        int VotosPositivos { get; set; }
        int VotosNegativos { get; set; }
        int NumeroComentarios { get; set; }
    }
}