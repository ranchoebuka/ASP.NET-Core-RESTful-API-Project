using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Entities
{
    public class FootballClub
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ManagerName { get; set; }
        [Required]
        public string StadiumName { get; set; }
        public double  stadiumCapacity { get; set; }

        public League League { get; set; }

        public string Honours { get; set; }

        public int LeagueId { get; set; }
    }
}
