using ECountry.Domain;
using ECountry.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECountry.Infrastructure.Mapping.Base
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
