using ECountry.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Domain.Repositories
{
    public interface IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Query();
        Task<TEntity> Find(params object[] keyValues);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    }
}
