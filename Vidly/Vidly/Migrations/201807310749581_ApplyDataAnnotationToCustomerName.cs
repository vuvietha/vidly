namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "Name", c => c.String());
        }
    }
}
