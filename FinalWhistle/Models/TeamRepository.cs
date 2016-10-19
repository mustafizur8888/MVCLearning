using System.Collections.Generic;
using System.Linq;

namespace FinalWhistle.Models
{
    public class TeamRepository
    {
        private readonly FWContext _context = new FWContext();
        public IEnumerable<Team> GetAllTeam()
        {


            var teams = _context.Teams.ToList();
            return teams;
        }

        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

    }
}