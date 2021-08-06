using ECountry.Application.Common.Mappings;
using ECountry.Domain;
using ECountry.Domain.Entities;

namespace ECountry.Application.Features.Fields.Models
{
    public class PropertyModel : IMapFrom<Property>
    {
        public string Name { get; set; }
        public PropertyType Type { get; set; }
    }
}
