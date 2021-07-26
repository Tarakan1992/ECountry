using ECountry.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace ECountry.Infrastructure.Mapping.Base
{
    public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
                where TEntity : class, IEntity<int>
    {
        protected virtual string TableName => string.Concat(typeof(TEntity).Name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(e => e.Id);
        }
    }
}
