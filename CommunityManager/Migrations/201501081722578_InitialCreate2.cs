namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Password2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Password2");
        }
    }
}
