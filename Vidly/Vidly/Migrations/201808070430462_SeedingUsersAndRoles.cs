namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7bd86274-164d-4140-ac5e-cd07c6c52951', N'admin@gmail.com', 0, N'ALPg7zsIe7JrjU25KQz9/Hck3anP54jpdVRzT5DCX9FxbpeRS6PQCmACBXuxV1kqvQ==', N'43e12e07-3f50-4384-b387-74266fda9c08', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'abad1388-0b28-480e-a839-38a99466c3de', N'vuvietha@gmail.com', 0, N'AK2Alid54Th5uTChxwBOVeYRfBj1h2tG6BsO6XfJkrZ3c1iEUQk9rgXgjIU4ve9GBg==', N'fef465f7-5515-46e4-bee2-3ebb86777b12', NULL, 0, 0, NULL, 1, 0, N'vuvietha@gmail.com')
 INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4e46a0a5-2eb2-4b91-ae7e-026e5363b084', N'CanManageMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7bd86274-164d-4140-ac5e-cd07c6c52951', N'4e46a0a5-2eb2-4b91-ae7e-026e5363b084')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'abad1388-0b28-480e-a839-38a99466c3de', N'4e46a0a5-2eb2-4b91-ae7e-026e5363b084')
"

                );
        }

        public override void Down()
        {
        }
    }
}
