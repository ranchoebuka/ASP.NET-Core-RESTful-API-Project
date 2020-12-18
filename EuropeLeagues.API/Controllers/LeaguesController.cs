using AutoMapper;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Entities;
using EuropeLeagues.API.Repository;
using EuropeLeagues.API.SearchUtilities;
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
        private readonly IMapper _mapper;
        public LeaguesController(IEuropeanLeaguesRepository repo, IMapper mapper)
        {
            _euroLeagueRepo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<LeagueDto>> GetLeagues([FromQuery] LeagueSearchCriteria searchcriteria)
        {
            var leagues = _euroLeagueRepo.GetLeagues(searchcriteria);

            return Ok(_mapper.Map<IEnumerable<LeagueDto>>(leagues)); // Ok can return any document type (Json,Xml, etc)
        }

        [HttpGet("{leagueId}", Name = "GetLeagueEntity")]
        public ActionResult<LeagueDto> GetLeague(int leagueId)
        {
            var league = _euroLeagueRepo.GetLeague(leagueId);
            if (league == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LeagueDto>(league));
        }

        [HttpPost]
        public ActionResult<LeagueDto> CreateLeague(LeagueCreationDto league)
        {
            var leagueEntity = _mapper.Map<League>(league);
            _euroLeagueRepo.AddLeague(leagueEntity);
            _euroLeagueRepo.Save();

            var returnedleague = _mapper.Map<LeagueDto>(leagueEntity);
            return CreatedAtRoute("GetLeagueEntity",
                new { leagueId = returnedleague.Id },
                returnedleague);

        }

        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
