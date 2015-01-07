using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityManager.DataAccessLayer;
using CommunityManager.Models;

namespace CommunityManager.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
    }

    public class UsuarioService : IUsuarioService
    {
        public List<Usuario> Todos()
        {
            var dbContext = new CommunityContext();
            return dbContext.Usuarios.ToList();
        }
    }
}