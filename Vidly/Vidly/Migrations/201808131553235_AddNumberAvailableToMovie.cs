namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieModels", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("Update dbo.MovieModels set NumberAvailable = Quantity");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieModels", "NumberAvailable");
        }
    }
}
