namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourtTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CourtTypes (Id, Type, Price) VALUES (1,'basketball', 1500)");
            Sql("INSERT INTO CourtTypes (Id, Type, Price) VALUES (2, 'football', 2000)");
            Sql("INSERT INTO CourtTypes (Id, Type, Price) VALUES (3, 'tennis', 3000)");
        }
        
        public override void Down()
        {
        }
    }
}
