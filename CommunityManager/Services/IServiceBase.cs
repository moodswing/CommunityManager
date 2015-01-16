using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityManager.Services
{
    public interface IServiceBase<T, in TK>
    {
        List<T> Todos();
        T ObtenerPorId(int id);
        void Actualizar(T registro, TK viewModel);
    }
}