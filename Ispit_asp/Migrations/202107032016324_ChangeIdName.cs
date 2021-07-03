namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Courts");
            DropColumn("dbo.Courts", "Id");
            AddColumn("dbo.Courts", "CourtId", c => c.Int(nullable: false, identity: true));
            
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courts", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Courts");
            DropColumn("dbo.Courts", "CourtId");
            AddPrimaryKey("dbo.Courts", "Id");
        }
    }
}
