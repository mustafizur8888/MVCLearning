namespace FinalWhistle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchreport2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "MatchId", "dbo.MatchReports");
            DropIndex("dbo.Matches", new[] { "MatchId" });
            DropPrimaryKey("dbo.Matches");
            AlterColumn("dbo.Matches", "MatchId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Matches", "MatchId");
            CreateIndex("dbo.MatchReports", "MatchId");
            AddForeignKey("dbo.MatchReports", "MatchId", "dbo.Matches", "MatchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchReports", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchReports", new[] { "MatchId" });
            DropPrimaryKey("dbo.Matches");
            AlterColumn("dbo.Matches", "MatchId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Matches", "MatchId");
            CreateIndex("dbo.Matches", "MatchId");
            AddForeignKey("dbo.Matches", "MatchId", "dbo.MatchReports", "Id");
        }
    }
}
