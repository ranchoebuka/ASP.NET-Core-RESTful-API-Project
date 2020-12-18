using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Entities
{
    public class League
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTimeOffset DateofCreation { get; set; }

        [Required]
        public string Country { get; set; }

        public string Group { get; set; }

        public ICollection<FootballClub> Clubs { get; set; } = new List<FootballClub>();
    }
}
