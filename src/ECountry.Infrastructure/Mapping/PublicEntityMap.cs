using ECountry.Domain;
using ECountry.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECountry.Infrastructure.Mapping
{
    public class PublicEntityMap<TPublicEntity> : EntityMap<TPublicEntity>
        where TPublicEntity : PublicEntity
    {
        public override void Configure(EntityTypeBuilder<TPublicEntity> builder)
        {
            base.Configure(builder);

            var converter = new ValueConverter<SGuid, string>(
                v => v.ToString(),
                v => new SGuid(v));

            builder.Property(e => e.PublicId).HasConversion(converter).HasValueGenerator<SGuidValueGenerator>().IsRequired();
        }
    }
}
