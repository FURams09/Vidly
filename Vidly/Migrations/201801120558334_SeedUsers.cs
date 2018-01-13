namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
			Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
				VALUES (N'1f0fae7a-feba-4693-9be2-49f3ae1ff1bf', N'admin@mail.com', 0, N'AOL49nxwshgcvxkskfIWvabx7Eq2xhdWTtWOZkBgZiE7LsFZ/qgs/fJsLU32GC+YAw==', N'd0cf53af-b625-4758-8f44-d6564442dc7d', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
				INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
				VALUES (N'aef55798-3112-4746-ba7d-72f4ab3e063b', N'fake@mail.com', 0, N'APhre762Y3iJDLXKTcIfZHOEiTdPV+vFR+GOJkJ9iJvoZVZRU8eSbNR8aj/RHls7Fg==', N'4221a6b6-088d-4205-8333-ea1ae4da1e59', NULL, 0, 0, NULL, 1, 0, N'fake@mail.com')
				INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
				VALUES (N'fbef9755-b83a-493d-afec-480cd282b475', N'greg@fake.com', 0, N'AGF2N+0zKPhmoIdNdvlodwSI+w1OAAlzNac/kUbdrCNhZYeklvxc7yFdhaaIOMo2iA==', N'97bdba9f-1b7c-4b2b-89a3-a2d52e3bb339', NULL, 0, 0, NULL, 1, 0, N'greg@fake.com')");
			Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5877b1b5-7946-4c5b-8de7-5687d1176c38', N'{Models.RoleNames.CanManageMovies}')" );
			Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1f0fae7a-feba-4693-9be2-49f3ae1ff1bf', N'5877b1b5-7946-4c5b-8de7-5687d1176c38')");
		
        }
        
        public override void Down()
        {
			Sql("Delete from AspNetUsers where Id in (N'aef55798-3112-4746-ba7d-72f4ab3e063b',N'1f0fae7a-feba-4693-9be2-49f3ae1ff1bf', N'fbef9755-b83a-493d-afec-480cd282b475')");
			Sql("Delete from AspNetUserRoles where UserId = N'1f0fae7a-feba-4693-9be2-49f3ae1ff1bf' and RoleID = N'5877b1b5-7946-4c5b-8de7-5687d1176c38')");
			Sql("Delete from AspNetRoles where Id = 'N'5877b1b5-7946-4c5b-8de7-5687d1176c38')");
		}
    }
}
