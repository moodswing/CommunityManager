namespace CommunityManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "Password2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Password2", c => c.String());
        }
    }
}
