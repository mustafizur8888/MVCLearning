using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FinalWhistle.Models
{
    public class MatchViewModel
    {
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        [DataType(DataType.Date)]
        public DateTime Timestamp { get; set; }

        public List<Team> HomTeams { get; set; }
        public List<Team> AwayTeams { get; set; }
    }
}