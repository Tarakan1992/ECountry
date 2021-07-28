using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECountry.Application.CQRS;
using ECountry.Application.Features.Fields.Models;
using ECountry.Domain.Entities;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.Fields.Queries
{
    public record GetFieldsQuery : IQuery<IEnumerable<FieldModel>>
    {
    }

    public class GetFieldsQueryHandler : IQueryHandler<GetFieldsQuery, IEnumerable<FieldModel>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFieldsQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<FieldModel>>> Handle(GetFieldsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Field>().ProjectTo<FieldModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
