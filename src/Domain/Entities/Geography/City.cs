using Zen.Domain.Entities.Entity;

namespace ZenAchitecture.Domain.Entities.Geography
{
    public class City : Entity
    {

        public string Name { get; private set; }

        public static City Create(string name) => new()
        {
            Name = name?.Trim()
        };

        public void UpdateInfo(string name) => Name = name;

        public City Copy()
        {
            var entity = new City
            {
                Name = this.Name

            };

            return entity;
        }

    }
}