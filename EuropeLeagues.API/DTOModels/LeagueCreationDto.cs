using EuropeLeagues.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DTOModels
{
    public class LeagueCreationDto
    {
        public string Name { get; set; }

        public DateTimeOffset DateofCreation { get; set; }

        public string Country { get; set; }

        public string Group { get; set; }

        public ICollection<FootballClub> Clubs { get; set; } = new List<FootballClub>();
    }
}
