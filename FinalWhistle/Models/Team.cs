using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalWhistle.Models
{
    public class Team
    {

        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public ICollection<Match> HomeMatches { get; set; }

        public ICollection<Match> AwayMatches { get; set; }
    }

    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        public DateTime Timestamp { get; set; }
           
        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }
        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        
    }

    public class MatchReport
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public Match Match { get; set; }

    }




}
