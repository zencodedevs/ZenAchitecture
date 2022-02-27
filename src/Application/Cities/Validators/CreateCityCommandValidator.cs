using ZenAchitecture.Application.Account.Cities.Commands;
using ZenAchitecture.Application.Account.Cities.Dtos;
using ZenAchitecture.Application.Common.Validator;
using ZenAchitecture.Domain.Entities.Geography;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zen.Domain.Interfaces;

namespace ZenAchitecture.Application.Account.Cities.Validators
{
    public class CreateCityCommandValidator : ZenAbstractValidator<CreateCityCommand>
    {
        private readonly IEntityFrameworkRepository<City> _cityRepository;

        public CreateCityCommandValidator(
            IServiceScopeFactory serviceScopeFactory,
            IEntityFrameworkRepository<City> cityRepository)
            : base(serviceScopeFactory)
        {

            _cityRepository = cityRepository;

           
            RuleFor(x => x.Translations)
               .Must(ValidateTranslationFieldsLengts).WithMessage(string.Format(_stringLocalizer.GetString("MaximumSize"), 100));
        }

        private bool ValidateTranslationFieldsLengts(List<CityTranslationDto> Translations)
        {
            if (Translations.Any(x => x.Name?.Length > 100))
                return false;

            return true;
        }

        
    }
}
