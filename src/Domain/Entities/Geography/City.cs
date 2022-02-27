using System;
using System.Collections.Generic;
using Zen.Domain.Entities.Entity;
using Zen.MultiTenancy;

namespace ZenAchitecture.Domain.Entities.Geography
{
    public class City : Entity, IMultiTenant
    {
        public int CountryId { get; set; }

        public ICollection<CityTranslation> Translations { get; set; }

        public Guid? TenantId { get; set; }

        public static City Create(List<CityTranslation> translations, int countryId) => new()
        {
            CountryId = countryId,
            Translations = translations
        };

        public static City Create(List<CityTranslation> translations) => new()
        {
            Translations = translations
        };

        public void UpdateInfo(List<CityTranslation> translations) => Translations = translations;

        public City Copy()
        {
            var entity = new City
            {
                CountryId = this.CountryId,
                Translations = new List<CityTranslation>(),

            };
            foreach (var item in this.Translations)
            {
                entity.Translations.Add(new CityTranslation
                {
                    Language = item.Language,
                    Name = item.Name
                });
            }
            return entity;
        }

       
    }
}