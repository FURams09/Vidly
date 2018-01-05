namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
			Sql("Insert into MembershipTypes VALUES (1, 0, 0, 0)");
			Sql("Insert into MembershipTypes VALUES (2, 30, 1, 10)");
			Sql("Insert into MembershipTypes VALUES (3, 90, 3, 15)");
			Sql("Insert into MembershipTypes VALUES (4, 300, 12, 20)");
		}
        
        public override void Down()
        {
			Sql("Delete from MembershipTypes");
        }
    }
}
