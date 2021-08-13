using System;
using System.Linq;

namespace ECountry.Domain.Entities
{
    public class Property : Entity
    {
        public string Name { get; private set; }

        public PropertyType Type { get; private set; }

        public Property(string name, PropertyType type)
        {
            if(name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(name.Length > 100)
            {
                throw new ArgumentException("'Name' is too long");
            }

            if (!Enum.GetValues<PropertyType>().Contains(type))
            {
                throw new ArgumentException("'Property Type' is invalid");
            }

            Name = name;
            Type = type;
        }

        private Property()
        {

        }
    }
}
