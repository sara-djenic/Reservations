namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourtType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourtTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courts", "CourtTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courts", "CourtTypeId");
            AddForeignKey("dbo.Courts", "CourtTypeId", "dbo.CourtTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courts", "CourtTypeId", "dbo.CourtTypes");
            DropIndex("dbo.Courts", new[] { "CourtTypeId" });
            DropColumn("dbo.Courts", "CourtTypeId");
            DropTable("dbo.CourtTypes");
        }
    }
}
