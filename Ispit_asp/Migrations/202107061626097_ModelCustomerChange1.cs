namespace Ispit_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCustomerChange1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
            DropColumn("dbo.Customers", "LastName");
        }
    }
}
