using ECountry.Domain.Entities.Base;

namespace ECountry.Domain.Entities
{
    public class Field : Entity
    {
        public string Name { get; private set; }

        public DataType DataType { get; private set; }

        public Field(string name, DataType dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }
}
