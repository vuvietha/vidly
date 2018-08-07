namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhoneToMovie : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieModels", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieModels", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
