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

            return Ok(allLeaguesDto);
        }
    }
}
