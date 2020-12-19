using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.DTOModels.Updating_Resources
{
    public class FootballClubUpdateDto
    {
        public string ManagerName { get; set; }
        public string StadiumName { get; set; }
        public double stadiumCapacity { get; set; }
        public string Honours { get; set; }
    }
}
