namespace FinalWhistle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchreport3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MatchReports", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchReports", new[] { "MatchId" });
            AddColumn("dbo.Matches", "MatchReport_Id", c => c.Int());
            CreateIndex("dbo.Matches", "MatchReport_Id");
            AddForeignKey("dbo.Matches", "MatchReport_Id", "dbo.MatchReports", "Id");
            DropColumn("dbo.MatchReports", "MatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MatchReports", "MatchId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Matches", "MatchReport_Id", "dbo.MatchReports");
            DropIndex("dbo.Matches", new[] { "MatchReport_Id" });
            DropColumn("dbo.Matches", "MatchReport_Id");
            CreateIndex("dbo.MatchReports", "MatchId");
            AddForeignKey("dbo.MatchReports", "MatchId", "dbo.Matches", "MatchId", cascadeDelete: true);
        }
    }
}
