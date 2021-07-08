namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTimeSlots : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "TimeSlots");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "TimeSlots", c => c.Int(nullable: false));
        }
    }
}
