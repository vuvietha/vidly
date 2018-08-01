namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToGenere : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Generes(id, name) VALUES(1, 'Comedy')");
            Sql("INSERT INTO Generes(id, name) VALUES(2, 'Action')");
            Sql("INSERT INTO Generes(id, name) VALUES(3, 'Family')");
            Sql("INSERT INTO Generes(id, name) VALUES(4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
