namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCustomerChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
        }
    }
}
