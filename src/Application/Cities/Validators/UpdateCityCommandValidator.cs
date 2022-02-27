using System.Linq;
using System.Threading;
using FluentValidation;
using System.Threading.Tasks;
using Zen.Domain.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using ZenAchitecture.Domain.Entities.Geography;
using ZenAchitecture.Application.Account.Cities.Dtos;
using ZenAchitecture.Application.Account.Cities.Commands;
using ZenAchitecture.Application.Common.Validator;
using Microsoft.Extensions.DependencyInjection;
using Zen.Uow;

namespace ZenAchitecture.Application.Account.Cities.Validators
{
    public class UpdateCityCommandValidator : ZenAbstractValidator<UpdateCityCommand>
    {
        private readonly IEntityFrameworkRepository<City> _repository;

        public UpdateCityCommandValidator(IEntityFrameworkRepository<City> repository, IServiceScopeFactory serviceScopeFactory)
            : base(serviceScopeFactory)
        {

            _repository = repository;

            RuleFor(x => x.Translations)
                .NotNull().WithMessage(_stringLocalizer.GetString("FieldRequired"))
                .NotEmpty().WithMessage(_stringLocalizer.GetString("FieldRequired"));

            RuleFor(x => x.Translations)
                .MustAsync(ValidateTranslationFieldsLengts).WithMessage(string.Format(_stringLocalizer.GetString("MaximumSize"), 100));

            RuleFor(v => v.Id)
                .MustAsync(DepartmentExists).WithMessage(_stringLocalizer.GetString("RecordNotFound"));

        }
        private async Task<bool> DepartmentExists(int departmentId, CancellationToken cancellationToken)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                return await _repository.ExistAsync(departmentId, cancellationToken);
            }
        }


        private async Task<bool> ValidateTranslationFieldsLengts(List<CityTranslationDto> Translations, CancellationToken cancellationToken)
        {

            if (Translations.Any(x => x.Name?.Length > 100))
                return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}