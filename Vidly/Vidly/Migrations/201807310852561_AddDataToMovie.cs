namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieModels(name, releasedDate, addedDate, Quantity, GenereId) VALUES('Hangover','2009-6-11','2009-6-11',5,1)");
            Sql("INSERT INTO MovieModels( name, releasedDate, addedDate, Quantity, GenereId) VALUES('Die Hard','2009-7-12','2009-6-11',6,2)");
            Sql("INSERT INTO MovieModels( name, releasedDate, addedDate, Quantity, GenereId) VALUES('The Teminator','2010-8-13','2009-6-11',7,2)");
            Sql("INSERT INTO MovieModels( name, releasedDate, addedDate, Quantity, GenereId) VALUES('Toy Story','2009-9-14','2009-6-11',8,3)");
            Sql("INSERT INTO MovieModels( name, releasedDate, addedDate, Quantity, GenereId) VALUES('Titanic','2011-10-15','2009-6-11',9,4)");
        }
        
        public override void Down()
        {
        }
    }
}
