using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DTOModels
{
    public class LeagueDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }
    }
}
