using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CommunityManager.Models;
using CommunityManager.ViewModels.Acceso;
using CommunityManager.ViewModels.Portada;

namespace CommunityManager.Infrastructure.MappingProfiles
{
    public class PublicacionMappingProfiles : Profile
    {
        private const string ViewModel = "PublicacionViewModel";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<PublicacionViewModel, Publicacion>()
                    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                    .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                    .ForMember(dest => dest.FechaIngreso, opt => opt.MapFrom(src => src.FechaIngreso))
                    .ForMember(dest => dest.TipoPublicacion, opt => opt.MapFrom(src => src.TipoPublicacion))
                    .ForMember(dest => dest.VotosNegativos, opt => opt.MapFrom(src => src.VotosNegativos))
                    .ForMember(dest => dest.VotosPositivos, opt => opt.MapFrom(src => src.VotosPositivos))
                    .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios))
                    .IgnoreAllNonExisting()
                    .ReverseMap()
                    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                    .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                    .ForMember(dest => dest.FechaIngreso, opt => opt.MapFrom(src => src.FechaIngreso))
                    .ForMember(dest => dest.TipoPublicacion, opt => opt.MapFrom(src => src.TipoPublicacion))
                    .ForMember(dest => dest.VotosNegativos, opt => opt.MapFrom(src => src.VotosNegativos))
                    .ForMember(dest => dest.VotosPositivos, opt => opt.MapFrom(src => src.VotosPositivos))
                    .ForMember(dest => dest.Comentarios, opt => opt.MapFrom(src => src.Comentarios))
                    .IgnoreAllNonExistingSource();

            CreateMap<ResumenPublicacionViewModel, Publicacion>()
                    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FechaIngreso, opt => opt.MapFrom(src => src.FechaIngreso))
                    .ForMember(dest => dest.TipoPublicacion, opt => opt.MapFrom(src => src.TipoPublicacion))
                    .ForMember(dest => dest.VotosPositivos, opt => opt.MapFrom(src => src.VotosPositivos))
                    .ForMember(dest => dest.VotosNegativos, opt => opt.MapFrom(src => src.VotosNegativos))
                    .IgnoreAllNonExisting()
                    .ReverseMap()
                    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                    .ForMember(dest => dest.FechaIngreso, opt => opt.MapFrom(src => src.FechaIngreso))
                    .ForMember(dest => dest.TipoPublicacion, opt => opt.MapFrom(src => src.TipoPublicacion))
                    .ForMember(dest => dest.VotosPositivos, opt => opt.MapFrom(src => src.VotosPositivos))
                    .ForMember(dest => dest.NumeroComentarios, opt => opt.MapFrom(src => src.Comentarios.Count()))
                    .IgnoreAllNonExistingSource();

            CreateMap<ComentarioViewModel, Comentario>()
                    .ForMember(dest => dest.Texto, opt => opt.MapFrom(src => src.Texto))
                    .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                    .IgnoreAllNonExisting()
                    .ReverseMap()
                    .ForMember(dest => dest.Nombreusuario, opt => opt.MapFrom(src => src.Usuario.NombreUsuario))
                    .ForMember(dest => dest.Texto, opt => opt.MapFrom(src => src.Texto))
                    .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                    .IgnoreAllNonExistingSource();
        }
    }
}