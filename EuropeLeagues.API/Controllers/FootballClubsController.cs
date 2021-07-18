using AutoMapper;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Entities;
using EuropeLeagues.API.Repository;
using EuropeLeagues.API.SearchUtilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Controllers
{
    [ApiController]
    [Authorize]
    //[Route("api/leagues/{leagueId}/FootballClubs")]
    [Route("api/leagues/{leagueId}/{Controller}")]
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

        [HttpPatch("{clubid}")]
        public ActionResult partialUpdateFootballClub(int leagueId, int clubid,
            JsonPatchDocument<FootballClubCreationDto> clubPatchdocument)
        {
            if (!_footballRepo.LeagueExist(leagueId)) return NotFound();

            var clubtoupdate = _footballRepo.GetClub(leagueId, clubid);
            if (clubtoupdate == null)
            {
                //Upserting with PATCH
                var clubDto = new FootballClubCreationDto();
                clubPatchdocument.ApplyTo(clubDto, ModelState);

                if (!TryValidateModel(clubDto))
                {
                    return ValidationProblem(ModelState);
                }

                var clubToAdd = _mapper.Map<FootballClub>(clubDto);
                clubToAdd.Id = clubid;

                _footballRepo.AddFootballClub(leagueId, clubToAdd);
                _footballRepo.Save();

                var clubToReturn = _mapper.Map<FootballClubDto>(clubToAdd);

                return CreatedAtRoute("GetClubEntity",
                 new { leagueId = clubToReturn.LeagueId, FootballClubId = clubToReturn.Id }, clubDto);
            }

            var clubtoupdateDto = _mapper.Map<FootballClubCreationDto>(clubtoupdate);
            clubPatchdocument.ApplyTo(clubtoupdateDto,ModelState);
            if (!TryValidateModel(clubtoupdateDto))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(clubtoupdateDto, clubtoupdate);

            _footballRepo.Save();
            return NoContent();
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        [HttpDelete("{clubId}")]
        public ActionResult DeleteClubinLeague(int leagueId, int clubId)
        {
            if (!_footballRepo.LeagueExist(clubId))
            {
                return NotFound();
            }

            var clubfromleague = _footballRepo.GetClub(leagueId, clubId);

            if (clubfromleague == null)
            {
                return NotFound();
            }

            _footballRepo.DeleteFootballClub(clubfromleague);
            _footballRepo.Save();

            return NoContent();
        }
    }
}
