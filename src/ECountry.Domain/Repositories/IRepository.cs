using ECountry.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Domain.Repositories
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);       

        Task<bool> Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task SaveChanges();
    }
}
