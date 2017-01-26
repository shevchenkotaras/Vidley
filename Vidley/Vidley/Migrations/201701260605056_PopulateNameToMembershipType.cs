namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE membershipTypes set Name = 'Pay as You Go' where id = 1");
            Sql("UPDATE membershipTypes set Name = 'Monthly' where id = 2");
            Sql("UPDATE membershipTypes set Name = 'Quarterly' where id = 3");
            Sql("UPDATE membershipTypes set Name = 'Annual' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
