using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DTOModels
{
    public class FootballClubCreationDto
    {
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string StadiumName { get; set; }
        public double stadiumCapacity { get; set; }
    }
}
