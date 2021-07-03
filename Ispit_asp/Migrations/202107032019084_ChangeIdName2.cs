namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdName2 : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.Courts", "CourtId");

        }

        public override void Down()
        {
        }
    }
}
