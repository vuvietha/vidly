namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "Birthday");
        }
    }
}
