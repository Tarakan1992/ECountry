using ECountry.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECountry.Infrastructure.Mapping
{
    public class UserMap : EntityMap<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Groups).WithMany("_users");
        }
    }
}
