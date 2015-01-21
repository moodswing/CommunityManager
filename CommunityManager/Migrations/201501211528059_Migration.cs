namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Publicaciones",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Titulo = c.String(),
            //            FechaIngreso = c.DateTime(nullable: false),
            //            Descripcion = c.String(),
            //            VotosPositivos = c.Int(nullable: false),
            //            VotosNegativos = c.Int(nullable: false),
            //            Precio = c.Int(nullable: false),
            //            UsuarioID = c.Int(nullable: false),
            //            TipoPublicacion = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
            //    .Index(t => t.UsuarioID);
            
            //CreateTable(
            //    "dbo.Usuarios",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Email = c.String(),
            //            Nombre = c.String(),
            //            Apellido = c.String(),
            //            NombreUsuario = c.String(),
            //            NumeroVivienda = c.String(),
            //            EstadoUsuario = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Publicaciones", "UsuarioID", "dbo.Usuarios");
            //DropIndex("dbo.Publicaciones", new[] { "UsuarioID" });
            //DropTable("dbo.Usuarios");
            //DropTable("dbo.Publicaciones");
        }
    }
}
