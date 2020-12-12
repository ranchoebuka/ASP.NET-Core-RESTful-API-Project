using EuropeLeagues.API.DbContexts;
using EuropeLeagues.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Repository
{
    public class EuropeanLeaguesRepository : IEuropeanLeaguesRepository
    {
        private readonly EuropeLeagueContext _context;
        public EuropeanLeaguesRepository(EuropeLeagueContext europeLeagueContext)
        {
            _context = europeLeagueContext;
        }
        public FootballClub GetClub(int LeagueId, int ClubId)
        {
            if (LeagueId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }
            if (ClubId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }

            return _context.Clubs.ToList<FootballClub>().Where(x => x.LeagueId == LeagueId && x.Id == ClubId).FirstOrDefault();
        }

        public IEnumerable<FootballClub> GetClubs(int LeagueId)
        {
            if (LeagueId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }
            return _context.Clubs.ToList<FootballClub>().Where(x => x.LeagueId == LeagueId).OrderBy(c=>c.Id);
        }

        public League GetLeague(int LeagueId)
        {
            if (LeagueId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }
            return _context.Leagues.ToList<League>().FirstOrDefault(x => x.Id == LeagueId);
        }

        public IEnumerable<League> GetLeagues()
        {
            return _context.Leagues.ToList<League>();
        }
    }
}
