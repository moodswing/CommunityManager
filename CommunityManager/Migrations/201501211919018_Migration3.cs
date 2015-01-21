namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicacionesSeguidas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        PublicacionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publicaciones", t => t.PublicacionID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.UsuarioID)
                .Index(t => t.PublicacionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicacionesSeguidas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.PublicacionesSeguidas", "PublicacionID", "dbo.Publicaciones");
            DropIndex("dbo.PublicacionesSeguidas", new[] { "PublicacionID" });
            DropIndex("dbo.PublicacionesSeguidas", new[] { "UsuarioID" });
            DropTable("dbo.PublicacionesSeguidas");
        }
    }
}
