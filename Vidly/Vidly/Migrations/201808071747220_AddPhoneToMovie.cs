namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "Phone");
        }
    }
}
