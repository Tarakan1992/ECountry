using ECountry.Domain.Entities;
using Hommy.Form;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECountry.Infrastructure.Mapping
{
    public class FormMap : PublicEntityMap<Form>
    {
        public override void Configure(EntityTypeBuilder<Form> builder)
        {
            base.Configure(builder);

            var options = new JsonSerializerOptions()
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            options.Converters.Add(new ElementJsonConverter());

            var converter = new ValueConverter<FormDefinition, string>(
                x => JsonSerializer.Serialize((object)x, options),
                x => JsonSerializer.Deserialize<FormDefinition>(x, options));

            builder.Property(x => x.Definition).HasConversion(converter);
        }
    }
}
