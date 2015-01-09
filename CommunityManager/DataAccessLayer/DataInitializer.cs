using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using CommunityManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CommunityManager.DataAccessLayer
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<CommunityContext>
    {
        protected override void Seed(CommunityContext context)
        {
            //context.Usuarios.AddOrUpdate(p => p.Email,
            //    new Usuario { Email = "rob.arav@gmail.com", Password = "12345" },
            //    new Usuario { Email = "test@gmail.com", Password = "12345" },
            //    new Usuario { Email = "raravena@gmail.com", Password = "12345" });
        }
    }
}
