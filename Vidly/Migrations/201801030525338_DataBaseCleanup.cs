namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBaseCleanup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NoAvailable", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoAvailable");
        }
    }
}
