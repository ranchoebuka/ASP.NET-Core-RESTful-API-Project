using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Entities
{
    public class FootballClub
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManagerName { get; set; }

        public string StadiumName { get; set; }
        public double  stadiumCapacity { get; set; }

        public League League { get; set; }

        public string Honours { get; set; }

        public int LeagueId { get; set; }
    }
}
