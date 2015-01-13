namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "NumeroVivienda", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "NumeroVivienda");
        }
    }
}
