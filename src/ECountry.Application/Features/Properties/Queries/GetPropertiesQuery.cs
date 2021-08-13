using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECountry.Application.CQRS;
using ECountry.Application.Features.Properties.Models;
using ECountry.Domain.Entities;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.Properties.Queries
{
    public record GetPropertiesQuery : IQuery<PropertyModel[]>
    {
    }

    public class GetPropertiesQueryHandler : IQueryHandler<GetPropertiesQuery, PropertyModel[]>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPropertiesQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<PropertyModel[]>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Set<Property>().ProjectTo<PropertyModel>(_mapper.ConfigurationProvider).ToArrayAsync();

            return result;
        }
    }
}
