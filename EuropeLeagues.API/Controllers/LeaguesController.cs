using AutoMapper;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Entities;
using EuropeLeagues.API.Repository;
using EuropeLeagues.API.SearchUtilities;
using EuropeLeagues.API.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Controllers
{
    [ApiController]
    [Authorize]
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

            var previousPageLink = leagues.HasPrevious ?
                CreateAuthorsResourceUri(searchcriteria, ResourceUriType.PreviousPage) : null;

            var nextPageLink = leagues.HasNext ?
                CreateAuthorsResourceUri(searchcriteria, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = leagues.TotalCount,
                pageSize = leagues.PageSize,
                currentPage = leagues.CurrentPage,
                totalPages = leagues.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

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

        [HttpDelete("{leagueId}")]
        public ActionResult DeleteLeague(int leagueId)
        {
            var league = _euroLeagueRepo.GetLeague(leagueId);

            if (league == null)
            {
                return NotFound();
            }

            // cascade delete is here. so courses attached to this author will be deleted as well
            _euroLeagueRepo.DeleteLeague(league);

            _euroLeagueRepo.Save();

            return NoContent();
        }

        private string CreateAuthorsResourceUri(
           LeagueSearchCriteria leagueresourceparams,
           ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAuthors",
                      new
                      {
                          pageNumber = leagueresourceparams.PageNumber - 1,
                          paseSize = leagueresourceparams.PageSize,
                          leagueGroup = leagueresourceparams.leagueGroup
                      });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors",
                      new
                      {
                          pageNumber = leagueresourceparams.PageNumber + 1,
                          paseSize = leagueresourceparams.PageSize,
                          leagueGroup = leagueresourceparams.leagueGroup
                      });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetAuthors",
                    new
                    {
                       pageNumber = leagueresourceparams.PageNumber,
                       paseSize = leagueresourceparams.PageSize,
                       leagueGroup = leagueresourceparams.leagueGroup
                    });
            }

        }
    }
}
