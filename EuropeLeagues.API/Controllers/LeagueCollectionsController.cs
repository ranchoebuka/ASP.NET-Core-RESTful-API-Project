using AutoMapper;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Entities;
using EuropeLeagues.API.Repository;
using EuropeLeagues.API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Controllers
{
    [ApiController]
    [Route("api/leaguecollections")]
    public class LeagueCollectionsController : ControllerBase
    {
        private readonly IEuropeanLeaguesRepository _euroLeagueRepo;
        private readonly IMapper _mapper;
        public LeagueCollectionsController(IEuropeanLeaguesRepository repo, IMapper mapper)
        {
            _euroLeagueRepo = repo;
            _mapper = mapper;
        }

        [HttpGet("({ids})", Name ="GetCollection")]
        public IActionResult GetLeagueCollection([FromRoute] [ModelBinder(BinderType =typeof(ArrayModelBinder))]
        IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }
            var leagues = _euroLeagueRepo.GetLeagues(ids);

            if (ids.Count() != leagues.Count())
            {
                return NotFound();
            }

            var authorsToReturn = _mapper.Map<IEnumerable<LeagueDto>>(leagues);

            return Ok(authorsToReturn);
        }


        [HttpPost]
        public ActionResult<IEnumerable<LeagueDto>> CreateLeagues(IEnumerable<LeagueCreationDto> leagues)
        {
            var allLeagues = _mapper.Map<IEnumerable<League>>(leagues);

            foreach (var item in allLeagues)
            {
                _euroLeagueRepo.AddLeague(item);
            }
            _euroLeagueRepo.Save();

            var allLeaguesDto = _mapper.Map<IEnumerable<LeagueDto>>(allLeagues);

            var idsAsString = string.Join(",", allLeaguesDto.Select(a => a.Id));
            return CreatedAtRoute("GetCollection",
             new { ids = idsAsString },
             allLeaguesDto);
        }
    }
}
