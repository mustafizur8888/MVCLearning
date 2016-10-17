﻿using System.Data.Entity;
using FinalWhistle.Models;

public class FWContext : DbContext
{
    public FWContext() : base("FWContext")
    {

    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<MatchReport> TeamsMatchReports { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Match>().
            HasRequired(m => m.HomeTeam).
            WithMany(t => t.HomeMatches)
            .HasForeignKey(m => m.HomeTeamId)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<Match>().
           HasRequired(m => m.AwayTeam).
           WithMany(t => t.AwayMatches)
           .HasForeignKey(m => m.AwayTeamId)
           .WillCascadeOnDelete(false);
        base.OnModelCreating(modelBuilder);
    }
}