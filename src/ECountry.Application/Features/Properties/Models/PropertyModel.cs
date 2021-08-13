using AutoMapper;
using ECountry.Application.Common.Mappings;
using ECountry.Domain;
using ECountry.Domain.Entities;

namespace ECountry.Application.Features.Properties.Models
{
    public class PropertyModel : IMapFrom<Property>
    {
        public string Name { get; set; }
        public PropertyType Type { get; set; }
    }
}
