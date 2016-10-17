namespace FinalWhistle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchreport4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "MatchReport_Id", "dbo.MatchReports");
            DropIndex("dbo.Matches", new[] { "MatchReport_Id" });
            DropColumn("dbo.Matches", "MatchReport_Id");
            DropTable("dbo.MatchReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MatchReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matches", "MatchReport_Id", c => c.Int());
            CreateIndex("dbo.Matches", "MatchReport_Id");
            AddForeignKey("dbo.Matches", "MatchReport_Id", "dbo.MatchReports", "Id");
        }
    }
}
