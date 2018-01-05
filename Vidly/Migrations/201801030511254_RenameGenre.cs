namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "GenreName", c => c.String());
			Sql("Update Genres set GenreName = Genre");
            DropColumn("dbo.Genres", "genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "genre", c => c.String());
            DropColumn("dbo.Genres", "GenreName");
        }
    }
}
