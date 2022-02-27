using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZenAchitecture.Application.Account.Cities.Dtos;
using ZenAchitecture.Application.Account.Cities.Queries;
using ZenAchitecture.Application.Account.Cities.Commands;
using Zen.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ZenAchitecture.WebUI.Controllers.V1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CityController : ZenController
    {
        [HttpGet]
        [Route(nameof(ReadCity))]
        public async Task<CityDto> ReadCity() => await Mediator.Send(new GetCityQuery());

        [HttpGet]
        [Route(nameof(GetCities))]
        public async Task<List<CityDto>> GetCities() => await Mediator.Send(new GetCitiesQuery());

        [HttpGet]
        [Route(nameof(ReadCityByCountryId))]
        public async Task<List<CityDto>> ReadCityByCountryId(int CountryId) => await Mediator.Send(new GetCityByCountryIdQuery() { CountryId = CountryId });

        [HttpPost]
        [Route(nameof(CreateCity))]
        public async Task<int> CreateCity(CreateCityCommand command) => await Mediator.Send(command);

        [HttpPost]
        [Authorize]
        [Route((nameof(UpdateCity)))]
        public async Task<int> UpdateCity(UpdateCityCommand command) => await Mediator.Send(command);

        [HttpDelete]
        [Authorize]
        [Route((nameof(DeleteCity)))]
        public async Task<int> DeleteCity([FromQuery] DeleteCityCommand command) => await Mediator.Send(command);

    }
}
