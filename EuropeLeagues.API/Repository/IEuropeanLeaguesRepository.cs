using EuropeLeagues.API.Entities;
using EuropeLeagues.API.SearchUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Repository
{
    public interface IEuropeanLeaguesRepository
    {
        IEnumerable<FootballClub> GetClubs(int LeagueId, FootballClubSearchCriteria searchcriteria);
        FootballClub GetClub(int LeagueId, int ClubId);
        IEnumerable<League> GetLeagues(LeagueSearchCriteria searchcriteria);

        IEnumerable<League> GetLeagues(IEnumerable<int> ids);
        IEnumerable<FootballClub> GetClubsWithEqualorGreaterThanCapacity(int LeagueId, double capacity);
        League GetLeague(int LeagueId);
        bool LeagueExist(int leagueId);
        bool Save();
        void AddLeague(League league);

        void DeleteFootballClub(FootballClub club);

        void DeleteLeague(League league);

        void AddFootballClub(int leagueId, FootballClub footballClub);
    }
}
