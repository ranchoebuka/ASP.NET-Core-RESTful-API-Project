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

            var club =  _context.Clubs.ToList<FootballClub>().Where(x => x.LeagueId == LeagueId && x.Id == ClubId).FirstOrDefault();
            if (club!=null)
            {
                club.League = _context.Leagues.ToList<League>().Find(x => x.Id == LeagueId);
            }
           

            return club;
        }

        public IEnumerable<FootballClub> GetClubs(int LeagueId)
        {
            if (LeagueId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }
            var clubs =  _context.Clubs.ToList<FootballClub>().Where(x => x.LeagueId == LeagueId).OrderBy(c=>c.Id);

            var league = _context.Leagues.ToList<League>().Find(x => x.Id == LeagueId);

            foreach (var item in clubs)
            {
                item.League = league;
            }

            return clubs;
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

        public bool LeagueExist(int leagueId)
        {
            if (leagueId == 0)
            {
                throw new WrongIDException("Id Cannot be Zero");
            }

            return _context.Leagues.Any(x => x.Id == leagueId);
        }
    }
}
