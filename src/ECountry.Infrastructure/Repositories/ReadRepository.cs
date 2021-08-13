using ECountry.Domain.Entities;
using ECountry.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Infrastructure.Repositories
{
    public class ReadRepository<TEnity> : IReadRepository<TEnity>
        where TEnity : class, IEntity
    {
        protected readonly DbContext _dbContext;

        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEnity> Find(params object[] keyValues)
        {
            return await _dbContext.FindAsync<TEnity>(keyValues);
        }

        public Task<TEnity> FirstOrDefault(Expression<Func<TEnity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEnity>().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public IQueryable<TEnity> Query(Expression<Func<TEnity, bool>> expression)
        {
            return _dbContext.Set<TEnity>().Where(expression);
        }

        public IQueryable<TEnity> Query()
        {
            return _dbContext.Set<TEnity>();
        }
    }
}
