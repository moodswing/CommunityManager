using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityManager.Models;

namespace CommunityManager.ViewModels
{
    public abstract class BaseViewModel
    {
        public TipoPublicacion FiltrarPublicacionesPor { get; set; }
    }
}