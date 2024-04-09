namespace WebApplication10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTvShow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TVShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DownloadURL = c.String(),
                        ImageURL = c.String(),
                        Rating = c.Single(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TVShows");
        }
    }
}
