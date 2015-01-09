namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Password", c => c.String());
        }
    }
}
