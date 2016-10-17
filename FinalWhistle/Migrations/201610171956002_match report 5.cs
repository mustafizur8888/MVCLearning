namespace FinalWhistle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchreport5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchReports", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchReports", new[] { "MatchId" });
            DropTable("dbo.MatchReports");
        }
    }
}
