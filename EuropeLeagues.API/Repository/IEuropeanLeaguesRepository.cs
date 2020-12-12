using EuropeLeagues.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Repository
{
    public interface IEuropeanLeaguesRepository
    {
        IEnumerable<FootballClub> GetClubs(int LeagueId);
        FootballClub GetClub(int LeagueId, int ClubId);
        IEnumerable<League> GetLeagues();
        League GetLeague(int LeagueId);
    }
}
