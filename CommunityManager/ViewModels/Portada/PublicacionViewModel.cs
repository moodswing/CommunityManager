using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityManager.ViewModels.Portada
{
    public class PublicacionViewModel : BaseViewModel, IPublicacionViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int VotosPositivos { get; set; }
        public int VotosNegativos { get; set; }
    }

    public interface IPublicacionViewModel
    {
        int Id { get; set; }
        string Titulo { get; set; }
        string Descripcion { get; set; }
        DateTime FechaIngreso { get; set; }
        int VotosPositivos { get; set; }
        int VotosNegativos { get; set; }
    }
}