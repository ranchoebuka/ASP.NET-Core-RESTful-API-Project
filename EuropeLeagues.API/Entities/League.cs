using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Entities
{
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateofCreation { get; set; }

        public string Country { get; set; }

        public ICollection<FootballClub> Clubs { get; set; } = new List<FootballClub>();
    }
}
