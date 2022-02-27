using ZenAchitecture.Application.Account.Cities.Dtos;
using ZenAchitecture.Domain.Entities.Geography;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Zen.Domain.Interfaces;

namespace ZenAchitecture.Application.Account.Cities.Commands
{
    public class CreateCityCommand : IRequest<int>
    {
        public int CountryId { get; set; }
        public List<CityTranslationDto> Translations { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IEntityFrameworkRepository<City> _repository;

        public CreateCityCommandHandler(IEntityFrameworkRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var entityTranslations = new List<CityTranslation>();

            request.Translations.ForEach(x => entityTranslations.Add(new CityTranslation
            {
                Language = x.Language,
                Name = x.Name
            }));

            return (await _repository.InsertAsync(entity: City.Create(translations: entityTranslations, request.CountryId), autoSave: true, cancellationToken: cancellationToken)).Id;
        }
    }
}
