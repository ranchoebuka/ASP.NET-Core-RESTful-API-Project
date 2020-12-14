using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DTOModels
{
    public class FootballClubDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManagerName { get; set; }

        public string StadiumName { get; set; }

        public string LeagueName { get; set; }
    }
}
