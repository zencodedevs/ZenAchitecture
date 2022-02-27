using AutoMapper;
using ZenAchitecture.Domain.Entities.Geography;
using ZenAchitecture.Application.Common.Mappings;
using Zen.Application.Mappings;

namespace ZenAchitecture.Application.Account.Cities.Dtos
{
    public class CityTranslationDto : IMapFrom<CityTranslation>
    {
        public string Language { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile Profile) => Profile.CreateMap<CityTranslation, CityTranslationDto>();
    }
}
