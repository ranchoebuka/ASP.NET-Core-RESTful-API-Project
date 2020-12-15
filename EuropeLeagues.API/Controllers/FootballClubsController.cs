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
    [Route("api/leagues/{leagueId}/FootballClubs")]
    public class FootballClubsController:ControllerBase
    {
        private readonly IEuropeanLeaguesRepository _footballRepo;
        private readonly IMapper _mapper;
        public FootballClubsController(IEuropeanLeaguesRepository _repo, IMapper mapper)
        {
            _footballRepo = _repo;
            _mapper = mapper;
        }

        //Get Collection of Football Clubs
        [HttpGet]
        public ActionResult<IEnumerable<FootballClubDto>> GetClubsForLeague(int leagueId, 
            [FromQuery] FootballClubSearchCriteria searchcriteria)
        {
            if (!_footballRepo.LeagueExist(leagueId))
            {
                return NotFound();
            }
            var clubs = _footballRepo.GetClubs(leagueId, searchcriteria);

            return Ok(_mapper.Map<IEnumerable<FootballClubDto>>(clubs));
        }

      
        [HttpGet("{FootballClubId}", Name = "GetClubEntity")]
        public ActionResult<FootballClubDto> GetClubForLeague(int leagueId, int FootballClubId)
        {
            if (!_footballRepo.LeagueExist(leagueId))
            {
                return NotFound();
            }
            var club = _footballRepo.GetClub(leagueId,FootballClubId);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FootballClubDto>(club));
        }

        [HttpPost]
        public ActionResult<FootballClubDto> CreateClubForLeague(int leagueId, FootballClubCreationDto club)
        {
            if (!_footballRepo.LeagueExist(leagueId))
            {
                return NotFound();
            }
            var footballclub = _mapper.Map<FootballClub>(club);
            _footballRepo.AddFootballClub(leagueId, footballclub);
            _footballRepo.Save();

            var clubDto = _mapper.Map<FootballClubDto>(footballclub);
            return CreatedAtRoute("GetClubEntity",
                new {leagueId = clubDto.LeagueId, FootballClubId = clubDto.Id }, clubDto);
        }
    }
}
