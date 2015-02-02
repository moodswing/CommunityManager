namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Texto = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        PublicacionID = c.Int(nullable: false),
                        Publicacion_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publicaciones", t => t.Publicacion_ID)
                .ForeignKey("dbo.Publicaciones", t => t.PublicacionID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.UsuarioID)
                .Index(t => t.PublicacionID)
                .Index(t => t.Publicacion_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "PublicacionID", "dbo.Publicaciones");
            DropForeignKey("dbo.Comentarios", "Publicacion_ID", "dbo.Publicaciones");
            DropIndex("dbo.Comentarios", new[] { "Publicacion_ID" });
            DropIndex("dbo.Comentarios", new[] { "PublicacionID" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioID" });
            DropTable("dbo.Comentarios");
        }
    }
}
