using System;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Web.Security;
using CommunityManager.DataAccessLayer;
using CommunityManager.Models;
using System.Data.Entity.Migrations;
using WebMatrix.WebData;
using MoreLinq;

namespace CommunityManager.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CommunityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new AzureSqlGenerator());
        }

        protected override void Seed(CommunityContext context)
        {
            context.Usuarios.AddOrUpdate(p => p.Email,
                            new Usuario { Email = "rob.arav@gmail.com", NumeroVivienda = "1706", EstadoUsuario = EstadoUsuario.Activo, Nombre = "Robinson", Apellido = "Aravena", NombreUsuario = "Robs" });

            context.Publicaciones.AddOrUpdate(p => p.Titulo,
                            new Publicacion { Titulo = "Se regalan cachorros", Descripcion = "Son 5 cachorritos uyuyuyuy", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Regalo, UsuarioID = 5 },
                            new Publicacion { Titulo = "Regalo zapatos rotos", Descripcion = "Estan bien rotos pero igual se pueden usar (eso siempre)", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Regalo, UsuarioID = 5 },
                            new Publicacion { Titulo = "Acensores cada vez mas lentos", Descripcion = "Están cada vez mas lentos los acensores", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Reclamo, UsuarioID = 5, VotosPositivos = 1, VotosNegativos = 0 },
                            new Publicacion { Titulo = "Plantar mas flores", Descripcion = "Para que haya mas colorido en la comunidad!!", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Propuesta, UsuarioID = 5, VotosPositivos = 70000, VotosNegativos = 0 },
                            new Publicacion { Titulo = "Bajar los gastos comunes", Descripcion = "Tan caros que son..", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Propuesta, UsuarioID = 5, VotosPositivos = 50000, VotosNegativos = 0 },
                            new Publicacion { Titulo = "Hago aseo", Descripcion = "Ofrezco servicios para hacer aseo en el departamento", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Servicio, UsuarioID = 5, Precio = 15000 },
                            new Publicacion { Titulo = "Cuido pendejos malcriados", Descripcion = "Ofrezco servicios para criar un poco menos mal a su descendencia", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Servicio, UsuarioID = 5, Precio = 150000 },
                            new Publicacion { Titulo = "Televisor 500'", Descripcion = "Televisor LCD 500 pulgadas", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Venta, UsuarioID = 5, Precio = 500 },
                            new Publicacion { Titulo = "Radio Stereo'", Descripcion = "Radio Stereo 5000 watts", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Regalo, UsuarioID = 5 },
                            new Publicacion { Titulo = "Mueble Biblioteca'", Descripcion = "Mueble biblioteca para la televisión 3 años uso aproximado", FechaIngreso = DateTime.Now, 
                            TipoPublicacion = TipoPublicacion.Venta, UsuarioID = 5, Precio = 990000 });

            context.PublicacionesVistas.AddOrUpdate(p => p.Fecha,
                            new PublicacionVista { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 1 },
                            new PublicacionVista { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 6 },
                            new PublicacionVista { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 10 },
                            new PublicacionVista { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 7 },
                            new PublicacionVista { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 2 });            
            
            context.PublicacionesSeguidas.AddOrUpdate(p => p.Fecha,
                            new PublicacionSeguida { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 3 },
                            new PublicacionSeguida { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 4 },
                            new PublicacionSeguida { Fecha = DateTime.Now, UsuarioID = 5, PublicacionID = 5 });            
            
            context.Comentarios.AddOrUpdate(p => p.Texto,
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 3, Texto= "Si toda la razón!" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 4, Texto = "A mi también me pasó :(" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 4, Texto = "Aprende a escribir" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 4, Texto = "Deberían echarte" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 3, Texto = "Muy buena idea" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 7, Texto = "Aprende a escribiiiir :@" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 8, Texto = "Guauf" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 8, Texto = "Miau" },
                            new Comentario { Fecha = DateTime.Now, UsuarioId = 5, PublicacionId = 5, Texto = "Yo soy mas bacan!" });            
            
            WebSecurity.InitializeDatabaseConnection("CommunityContext", "Usuarios", "Id", "Email", true);

            if (!Roles.RoleExists("Administrador"))
                Roles.CreateRole("Administrador");

            if (!WebSecurity.UserExists("rob.arav@gmail.com"))
                WebSecurity.CreateUserAndAccount("rob.arav@gmail.com", "12345");

            var isInRole = false;

            Roles.GetRolesForUser("rob.arav@gmail.com").ForEach(r => { if (r == "Administrador") isInRole = true; });
            if (!isInRole) Roles.AddUsersToRoles(new[] { "rob.arav@gmail.com" }, new[] { "Administrador" });
        }
    }
}

public class AzureSqlGenerator : SqlServerMigrationSqlGenerator
{
    protected override void Generate(CreateTableOperation createTableOperation)
    {
        if ((createTableOperation.PrimaryKey != null)
            && !createTableOperation.PrimaryKey.IsClustered)
        {
            createTableOperation.PrimaryKey.IsClustered = true;
        }

        base.Generate(createTableOperation);
    }
}
