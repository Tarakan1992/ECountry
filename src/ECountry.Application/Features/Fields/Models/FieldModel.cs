using ECountry.Application.Common.Mappings;
using ECountry.Domain;
using ECountry.Domain.Entities;

namespace ECountry.Application.Features.Fields.Models
{
    public class FieldModel : IMapFrom<Field>
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
    }
}
