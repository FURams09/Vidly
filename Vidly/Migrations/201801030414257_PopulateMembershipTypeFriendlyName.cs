namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeFriendlyName : DbMigration
    {
        public override void Up()
        {
			Sql("Update MembershipTypes set FriendlyName = 'Pay as you Go' where DurationInMonths = 0");
			Sql("Update MembershipTypes set FriendlyName = 'Monthly' where DurationInMonths = 1 ");
			Sql("Update MembershipTypes set FriendlyName = 'Quarterly' where DurationInMonths = 3");
			Sql("Update MembershipTypes set FriendlyName = 'Annual' where DurationInMonths = 12");

		}
        
        public override void Down()
        {
			Sql("Update MembershipTypes set FriendlyName = null where DurationInMonths in (0, 1, 3, 12)");
        }
    }
}
