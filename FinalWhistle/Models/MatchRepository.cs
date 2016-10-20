using System.Collections.Generic;
using System.Linq;

namespace FinalWhistle.Models
{
    public class MatchRepository
    {
        readonly FWContext _context = new FWContext();

        public IEnumerable<Match> GetAll()
        {
            return _context.Matches.ToList();
        }

        public void Add(MatchViewModel viewModel)
        {
            var m = new Match
            {
                Timestamp = viewModel.Timestamp,
                AwayPoints = viewModel.AwayPoints,
                HomePoints = viewModel.HomePoints,
                HomeTeamId = viewModel.HomeTeamId,
                AwayTeamId = viewModel.AwayTeamId,
                MatchId = viewModel.MatchId
            };

            _context.Matches.Add(m);
            _context.SaveChanges();
        }

    }
}