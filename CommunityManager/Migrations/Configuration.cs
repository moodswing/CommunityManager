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
            //context.Usuarios.AddOrUpdate(p => p.Email,
            //                new Usuario { Email = "rob.arav@gmail.com", Password = "12345" },
            //                new Usuario { Email = "test@gmail.com", Password = "12345" },
            //                new Usuario { Email = "raravena@gmail.com", Password = "12345" });

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
