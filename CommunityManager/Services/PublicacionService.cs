using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommunityManager.DataAccessLayer;
using CommunityManager.Models;
using CommunityManager.ViewModels.Portada;
using Microsoft.Practices.Unity;
using MoreLinq;

namespace CommunityManager.Services
{
    public interface IPublicacionService : IServiceBase<Publicacion, PublicacionViewModel>
    {
        List<IResumenPublicacionViewModel> ResumenPorTipo(TipoPublicacion tipo);
        List<IResumenPublicacionViewModel> ListaResumen();
        List<IResumenPublicacionViewModel> ListaResumenVistasRecientes(int idUsuario);
        List<IResumenPublicacionViewModel> ListaResumenSeguidas(int idUsuario);
    }

    public class PublicacionService : IPublicacionService
    {
        #region >>> Dependencias

        [Dependency]
        public CommunityContext DbContext { get; set; }

        #endregion

        public List<IResumenPublicacionViewModel> ResumenPorTipo(TipoPublicacion tipo)
        {
            var publicaciones = DbContext.Publicaciones.Where(p => p.TipoPublicacion == tipo).ToList();
            return ObtenerListaResumen(publicaciones);
        }

        public List<IResumenPublicacionViewModel> ListaResumen()
        {
            var publicaciones = DbContext.Publicaciones.ToList();
            return ObtenerListaResumen(publicaciones);
        }

        public List<IResumenPublicacionViewModel> ListaResumenVistasRecientes(int idUsuario)
        {
            var publicaciones = DbContext.PublicacionesVistas.Where(p => p.UsuarioID == idUsuario).OrderByDescending(v => v.Fecha).Select(p => p.Publicacion).DistinctBy(p => p.ID).ToList();
            return ObtenerListaResumen(publicaciones);
        }

        public List<IResumenPublicacionViewModel> ListaResumenSeguidas(int idUsuario)
        {
            var publicaciones = DbContext.PublicacionesSeguidas.Where(p => p.UsuarioID == idUsuario).OrderByDescending(v => v.Fecha).Select(p => p.Publicacion).DistinctBy(p => p.ID).ToList();
            return ObtenerListaResumen(publicaciones);
        }

        private List<IResumenPublicacionViewModel> ObtenerListaResumen(List<Publicacion> publicaciones)
        {
            var listado = new List<IResumenPublicacionViewModel>();

            foreach (var publicacion in publicaciones)
            {
                var publicacionVm = new ResumenPublicacionViewModel();
                Mapper.Map(publicacion, publicacionVm);
                listado.Add(publicacionVm);
            }

            return listado;
        }

        public List<Publicacion> Todos()
        {
            return DbContext.Publicaciones.ToList();
        }

        public Publicacion ObtenerPorId(int id)
        {
            return DbContext.Publicaciones.FirstOrDefault(p => p.ID == id);
        }

        public void Actualizar(Publicacion registro, PublicacionViewModel viewModel)
        {
            Mapper.Map(viewModel, registro);
            DbContext.SaveChanges();
        }
    }
}