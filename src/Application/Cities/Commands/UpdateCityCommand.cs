using MediatR;
using System.Threading;
using Zen.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ZenAchitecture.Domain.Entities.Geography;
using ZenAchitecture.Application.Account.Cities.Dtos;

namespace ZenAchitecture.Application.Account.Cities.Commands
{
    public class UpdateCityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public List<CityTranslationDto> Translations { get; set; }
    }
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, int>
    {
        private readonly IEntityFrameworkRepository<City> _repository;

        public UpdateCityCommandHandler(IEntityFrameworkRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(request.Id, cancellationToken, p => p.Translations);

            var entityTranslations = new List<CityTranslation>();

            request.Translations.ForEach(x => entityTranslations.Add(new CityTranslation
            {
                Language = x.Language,
                Name = x.Name
            }));

            entity.UpdateInfo(entityTranslations);

            var res = await _repository.UpdateAsync(entity, true, cancellationToken);

            return res.Id;
        }
    }
}
