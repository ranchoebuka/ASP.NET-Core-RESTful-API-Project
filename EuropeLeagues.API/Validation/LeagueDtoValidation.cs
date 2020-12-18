using EuropeLeagues.API.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Validation
{
    public class LeagueDtoValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var leaguedto = (LeagueCreationDto)validationContext.ObjectInstance;
            var checkfornull = leaguedto.GetType().GetProperties().Any(x => x.GetValue(leaguedto) == null);
            if (checkfornull)
            {

                var NullProps = leaguedto.GetType().GetProperties().Where
                    (x => x.GetValue(leaguedto) == null).Any(gg=>gg.Name.ToLower() == "name" ||  gg.Name.ToLower() == "country") ;

                if (NullProps)
                {
                    return new ValidationResult(ErrorMessage,
                    new[] { nameof(LeagueCreationDto) });
                }

            }
            return ValidationResult.Success;

        }
    }
}
