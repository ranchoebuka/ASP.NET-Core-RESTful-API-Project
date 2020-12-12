using EuropeLeagues.API.Entities;
using EuropeLeagues.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Controllers
{
    [ApiController]
    [Route("api/leagues")]
    public class LeaguesController : ControllerBase
    {
        private readonly IEuropeanLeaguesRepository _euroLeagueRepo;
        public LeaguesController(IEuropeanLeaguesRepository repo)
        {
            _euroLeagueRepo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<League>> GetLeagues()
        {
            var leagues = _euroLeagueRepo.GetLeagues();

            return Ok(leagues); // Ok can return any document type (Json,Xml, etc)
        }

        [HttpGet("{leagueId}")]
        public ActionResult GetLeague(int leagueId)
        {
            var league = _euroLeagueRepo.GetLeague(leagueId);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(league);
        }
    }
}
