namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
			Sql("Insert Into Genres VALUES ( 'Comedy')");
			Sql("Insert Into Genres VALUES ('Action')");
			Sql("Insert Into Genres VALUES ( 'Romance')");
			Sql("Insert Into Genres VALUES ('Family')");
			Sql("Insert Into Genres VALUES ('Foreign')");
		}
        
        public override void Down()
        {
			Sql("Delete from Genres");
		}
    }
}
