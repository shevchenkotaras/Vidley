namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribeToCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribeToNewletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribeToNewletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
