using AutoMapper;
using System.Collections.Generic;
using ZenAchitecture.Domain.Entities.Geography;
using ZenAchitecture.Application.Common.Mappings;
using Zen.Application.Mappings;
using System.Globalization;
using System.Linq;

namespace ZenAchitecture.Application.Account.Cities.Dtos
{
    public class CityDto : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<CityTranslationDto> Translations { get; set; }


        public void Mapping(Profile Profile)
        {
            Profile.CreateMap<City, CityDto>()
                .ForMember(m => m.Title, o => o.MapFrom<TitleResolver>());
        }

        private class TitleResolver : IValueResolver<City, CityDto, string>
        {
            public string Resolve(City source, CityDto destination, string destMember, ResolutionContext context)
            {
                string sysLang = CultureInfo.CurrentCulture.Name;

                return source.Translations.FirstOrDefault(a => a.Language == sysLang)?.Name;
            }
        }
    }
}