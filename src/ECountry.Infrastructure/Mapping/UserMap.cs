using ECountry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECountry.Infrastructure.Mapping
{
    public class UserMap : EntityMap<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Groups).WithMany("_users").UsingEntity<UserGroup>(
                j => j.HasOne(x => x.Group).WithMany(),
                j => j.HasOne(x => x.User).WithMany());
        }
    }
}
