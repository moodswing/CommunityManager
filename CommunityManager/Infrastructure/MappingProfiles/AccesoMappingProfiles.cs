using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CommunityManager.Models;
using CommunityManager.ViewModels.Acceso;

namespace CommunityManager.Infrastructure.MappingProfiles
{
    public class AccesoMappingProfiles : Profile
    {
        private const string ViewModel = "IngresoDatosViewModel";

        public override string ProfileName
        {
            get { return ViewModel; }
        }

        protected override void Configure()
        {
            CreateMap<IngresoDatosViewModel, Usuario>()
                    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                    .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                    .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
                    .IgnoreAllNonExisting()
                    .ReverseMap()
                    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                    .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                    .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
                    .IgnoreAllNonExistingSource();
        }
    }
}