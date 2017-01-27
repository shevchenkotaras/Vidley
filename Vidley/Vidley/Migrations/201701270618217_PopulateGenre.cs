namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON;");
            Sql("Insert into Genres (Id, Name) values (1, 'Action')");
            Sql("Insert into Genres (Id, Name) values (2, 'Comedy')");
            Sql("Insert into Genres (Id, Name) values (3, 'Family')");
            Sql("Insert into Genres (Id, Name) values (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
