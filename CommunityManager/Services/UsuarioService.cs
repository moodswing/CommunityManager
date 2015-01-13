using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityManager.DataAccessLayer;
using CommunityManager.Models;
using Microsoft.Practices.Unity;

namespace CommunityManager.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
    }

    public class UsuarioService : IUsuarioService
    {
        [Dependency]
        public CommunityContext DbContext { get; set; }

        public List<Usuario> Todos()
        {
            return DbContext.Usuarios.ToList();
        }

        public Usuario ObtenerPorId(int id)
        {
            return DbContext.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}