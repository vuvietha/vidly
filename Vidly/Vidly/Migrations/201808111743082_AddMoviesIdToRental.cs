namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesIdToRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "MovieIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "MovieIds");
        }
    }
}
