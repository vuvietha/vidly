namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenereToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieModels", "GenereId", c => c.Byte(nullable: false));
            CreateIndex("dbo.MovieModels", "GenereId");
            AddForeignKey("dbo.MovieModels", "GenereId", "dbo.Generes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieModels", "GenereId", "dbo.Generes");
            DropIndex("dbo.MovieModels", new[] { "GenereId" });
            DropColumn("dbo.MovieModels", "GenereId");
            DropTable("dbo.Generes");
        }
    }
}
