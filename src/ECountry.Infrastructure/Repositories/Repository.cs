using ECountry.Domain.Entities;
using ECountry.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Infrastructure.Repositories
{
    public class Repository<TEntity> : ReadRepository<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public Repository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Attach(entity);

            return await Task.FromResult(_dbContext.Set<TEntity>().Update(entity).Entity);
        }

        public virtual async Task<bool> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            return await Task.FromResult(true);
        }
        
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
