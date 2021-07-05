namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerCourts",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Court_CourtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Court_CourtId })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Courts", t => t.Court_CourtId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Court_CourtId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCourts", "Court_CourtId", "dbo.Courts");
            DropForeignKey("dbo.CustomerCourts", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerCourts", new[] { "Court_CourtId" });
            DropIndex("dbo.CustomerCourts", new[] { "Customer_CustomerId" });
            DropTable("dbo.CustomerCourts");
            DropTable("dbo.Customers");
        }
    }
}
