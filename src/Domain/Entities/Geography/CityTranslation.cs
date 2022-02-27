using Zen.Domain.Entities.MultiLingual;

namespace ZenAchitecture.Domain.Entities.Geography
{
    public class CityTranslation : EntityTranslation<City>
    {
        public string Name { get; set; }
    }
}
