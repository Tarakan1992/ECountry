using ECountry.Application.CQRS;
using ECountry.Domain.Entities;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.App.Queries
{
    public record PingQuery() : IQuery<string>;

    public class PingQueryHandler : IQueryHandler<PingQuery, string>
    {
        private readonly DbContext _dbContext;

        public PingQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<string>> Handle(PingQuery request, CancellationToken cancellationToken)
        {
            var version = (await _dbContext.Set<DbVersion>().FirstAsync()).Version;

            return version;
        }
    }
}
