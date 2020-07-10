namespace VidlyLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1cf0556e-ecdc-4ff2-8bda-cad1c4a35034', N'emekatorti@gmail.com', 0, N'ADRdNQxKYDyFWnbaJxmFpMXMWQhjieQUmLxqgQl1sbcECMSTLLr6Z+6utDkVGA6cJg==', N'7f34f8ad-f06b-4c6b-b90a-63f08a240c27', NULL, 0, 0, NULL, 1, 0, N'emekatorti@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'568e5b16-f706-42cd-9bfc-f3a981cb1793', N'admin@mive.com', 0, N'AGuMN59C++gpzyn+FABbqjYvsdvqJY5TYfTZstzU8Jc9x6Mik0tXR3Dnf4KY9Z+ksA==', N'cb0029b4-7e75-42ab-9f5c-b7a2958c121a', NULL, 0, 0, NULL, 1, 0, N'admin@mive.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'86a4d2be-6dcc-41fd-a773-08d14d471efe', N'guest@mek.com', 0, N'AHP6cdvVNylBkq4M2PPlkXL7NxlmcyCd6G7bo+GfAYQuquVBSm1SkUo3XfLnVrUweg==', N'27760e27-bdcc-49da-9067-671e95a79fc3', NULL, 0, 0, NULL, 1, 0, N'guest@mek.com')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'568e5b16-f706-42cd-9bfc-f3a981cb1793', N'da71f73c-cba5-44c7-81fc-dd67ae7713cb')

");
        }
        
        public override void Down()
        {
        }
    }
}
