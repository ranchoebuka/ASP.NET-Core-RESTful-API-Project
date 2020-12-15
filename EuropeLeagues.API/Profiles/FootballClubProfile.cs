using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Entities;

namespace EuropeLeagues.API.Profiles
{
    public class FootballClubProfile : Profile
    {
        public FootballClubProfile()
        {
            CreateMap<FootballClub, FootballClubDto>()
                .ForMember(x => x.LeagueName, c => c.MapFrom(d => d.League.Name))
                .ForMember(x => x.LeagueId, c => c.MapFrom(d => d.League.Id));

            CreateMap<FootballClubCreationDto, FootballClub>();
        }
    }
}
