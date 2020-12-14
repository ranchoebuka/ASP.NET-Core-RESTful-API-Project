using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using EuropeLeagues.API.Entities;
using EuropeLeagues.API.DTOModels;
using EuropeLeagues.API.Utilities;

namespace EuropeLeagues.API.Profiles
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<League, LeagueDto>().ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofCreation.GetCurrentAge())); ;
        }
    }
}
