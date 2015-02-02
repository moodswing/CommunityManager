namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentarios", "Publicacion_ID", "dbo.Publicaciones");
            DropIndex("dbo.Comentarios", new[] { "Publicacion_ID" });
            DropColumn("dbo.Comentarios", "Publicacion_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comentarios", "Publicacion_ID", c => c.Int());
            CreateIndex("dbo.Comentarios", "Publicacion_ID");
            AddForeignKey("dbo.Comentarios", "Publicacion_ID", "dbo.Publicaciones", "ID");
        }
    }
}
