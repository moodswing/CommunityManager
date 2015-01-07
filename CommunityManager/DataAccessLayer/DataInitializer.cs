using System.Collections.Generic;
using System.Data.Entity;
using CommunityManager.Models;

namespace CommunityManager.DataAccessLayer
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<CommunityContext>
    {
        protected override void Seed(CommunityContext context)
        {
            var students = new List<Usuario>
            {
                new Usuario { Email = "rob.arav@gmail.com", Password = "12345" },
                new Usuario { Email = "test@gmail.com", Password = "12345" },
                new Usuario { Email = "raravena@gmail.com", Password = "12345" }
            };

            students.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}
