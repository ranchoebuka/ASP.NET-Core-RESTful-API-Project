using AutoMapper;
using EuropeLeagues.API.DTOModels;
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
        private readonly IMapper _mapper;
        public LeaguesController(IEuropeanLeaguesRepository repo, IMapper mapper)
        {
            _euroLeagueRepo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<LeagueDto>> GetLeagues()
        {
            var leagues = _euroLeagueRepo.GetLeagues();

            return Ok(_mapper.Map<IEnumerable<LeagueDto>>(leagues)); // Ok can return any document type (Json,Xml, etc)
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
