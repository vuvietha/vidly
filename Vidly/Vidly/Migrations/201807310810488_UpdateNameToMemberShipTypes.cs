namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameToMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Membershiptypes SET name = 'Pay as you go' WHERE id = 1");
            Sql("UPDATE Membershiptypes SET name = 'Monthly' WHERE id = 2");
            Sql("UPDATE Membershiptypes SET name = 'Quarterly' WHERE id = 3");
            Sql("UPDATE Membershiptypes SET name = 'Annually' WHERE id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
