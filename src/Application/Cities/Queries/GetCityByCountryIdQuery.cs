using MediatR;
using AutoMapper;
using System.Linq;
using System.Threading;
using Zen.Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZenAchitecture.Domain.Entities.Geography;
using ZenAchitecture.Application.Account.Cities.Dtos;

namespace ZenAchitecture.Application.Account.Cities.Queries
{
    public class GetCityByCountryIdQuery : IRequest<List<CityDto>>
    {
        public int CountryId { get; set; }
    }
    public class GetCityByCountryIdQueryHandler : IRequestHandler<GetCityByCountryIdQuery, List<CityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEntityFrameworkRepository<City> _repository;

        public GetCityByCountryIdQueryHandler(IEntityFrameworkRepository<City> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CityDto>> Handle(GetCityByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _repository.GetQueryableWithDataFilterAsync();

            var entities = await query
            .Where(x => x.CountryId == request.CountryId)
            .Include(p => p.Translations)
            .OrderByDescending(x => x.Id)
            .ToListAsync(cancellationToken);

            return _mapper.Map<List<CityDto>>(entities);

        }
    }
}
