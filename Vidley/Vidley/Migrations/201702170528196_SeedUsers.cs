namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'022e5150-4fc7-41f8-9fd4-7ec3e888391a', N'admin@vidley.com', 0, N'ABkxF0Sy6T0erTlzKW2SXH6CzD1Pz3kXSc90cDMhxNYQ5nO21v67G30dVi+IyoeNoA==', N'12e94a22-cc0a-4ff3-9e3f-de9306f6aa89', NULL, 0, 0, NULL, 1, 0, N'admin@vidley.com')

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f91d62bd-5733-472d-9688-2f4d457a19bf', N'guest@vidley.com', 1, N'ADhuMrT5V1eBbzK+utyLKTgfvBO8rsHse37vTR43kYZA+2h2sVqQuIjqNFGjKE7fzw==', N'29172c5b-ceb4-4f6a-a834-91e3f39a3ee7', NULL, 0, 0, NULL, 1, 0, N'guest@vidley.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'049c94ce-7fdd-45b6-8fb0-dc01c6c384cd', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'022e5150-4fc7-41f8-9fd4-7ec3e888391a', N'049c94ce-7fdd-45b6-8fb0-dc01c6c384cd')");
        }
        
        public override void Down()
        {
        }
    }
}
