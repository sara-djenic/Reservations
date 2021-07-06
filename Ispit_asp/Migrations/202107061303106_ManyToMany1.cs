namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany1 : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        CourtId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        TimeSlots = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Courts", t => t.CourtId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CourtId)
                .Index(t => t.CustomerId);
            
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerCourts",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Court_CourtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Court_CourtId });
            
            DropForeignKey("dbo.Reservations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "CourtId", "dbo.Courts");
            DropIndex("dbo.Reservations", new[] { "CustomerId" });
            DropIndex("dbo.Reservations", new[] { "CourtId" });
            DropTable("dbo.Reservations");
            CreateIndex("dbo.CustomerCourts", "Court_CourtId");
            CreateIndex("dbo.CustomerCourts", "Customer_CustomerId");
            AddForeignKey("dbo.CustomerCourts", "Court_CourtId", "dbo.Courts", "CourtId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerCourts", "Customer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
