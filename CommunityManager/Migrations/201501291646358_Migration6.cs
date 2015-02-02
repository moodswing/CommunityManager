namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comentarios", new[] { "UsuarioID" });
            DropIndex("dbo.Comentarios", new[] { "PublicacionID" });
            CreateIndex("dbo.Comentarios", "UsuarioId");
            CreateIndex("dbo.Comentarios", "PublicacionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comentarios", new[] { "PublicacionId" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioId" });
            CreateIndex("dbo.Comentarios", "PublicacionID");
            CreateIndex("dbo.Comentarios", "UsuarioID");
        }
    }
}
