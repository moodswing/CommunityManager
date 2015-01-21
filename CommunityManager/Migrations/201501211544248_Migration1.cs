namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicacionesVistas",
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
            DropForeignKey("dbo.PublicacionesVistas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.PublicacionesVistas", "PublicacionID", "dbo.Publicaciones");
            DropIndex("dbo.PublicacionesVistas", new[] { "PublicacionID" });
            DropIndex("dbo.PublicacionesVistas", new[] { "UsuarioID" });
            DropTable("dbo.PublicacionesVistas");
        }
    }
}
