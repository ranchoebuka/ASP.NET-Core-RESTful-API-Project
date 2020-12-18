using EuropeLeagues.API.DTOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Validation
{
    public class FootballClubDtoValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var clubdto = (FootballClubCreationDto)validationContext.ObjectInstance;
            var checkfornull = clubdto.GetType().GetProperties().Any(x => x.GetValue(clubdto) == null);
            if (checkfornull)
            {

                var NullProps = clubdto.GetType().GetProperties().Where
                    (x => x.GetValue(clubdto) == null)
                    .Any(gg => gg.Name.ToLower() == "name" || gg.Name.ToLower() == "managername"
                    || gg.Name.ToLower() == "stadiumname");

                if (NullProps)
                {
                    return new ValidationResult(ErrorMessage,
                    new[] { nameof(FootballClubCreationDto) });
                }

            }
            return ValidationResult.Success;
        }
    }
}
