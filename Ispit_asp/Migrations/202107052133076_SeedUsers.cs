namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'26d18a3c-7594-42e5-94f3-6a0675f95288', N'user@user.com', 0, N'AGZf9C7iO93JG/nEpt6pidwMrkJQKOrfbz6Oc9+pZPr/njgjmeuSc5uI9KziaDLNmw==', N'c3696f60-07b2-472d-9dc3-718a64dd53a8', NULL, 0, 0, NULL, 1, 0, N'user@user.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3f7e431a-7d4b-4c72-8267-c0107305e89e', N'admin@admin.com', 0, N'ALm9YJaKaUpfC09bzm2tlDh9yO9Swy+v6syfDYU7zsrVHlq5UD2kH4C3IVI9nRYk9w==', N'c0405535-b7c1-4d04-90f7-5b6a6e7e7071', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')                
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5dd73fd4-5e64-4853-ae0a-b72b2f3b6259', N'admin')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3f7e431a-7d4b-4c72-8267-c0107305e89e', N'5dd73fd4-5e64-4853-ae0a-b72b2f3b6259')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
