using AutoMapper;
using AutoMapper.QueryableExtensions;
using ECountry.Application.CQRS;
using ECountry.Application.Features.Users.Models;
using ECountry.Domain;
using ECountry.Domain.Entities;
using ECountry.Domain.Repositories;
using Hommy.ResultModel;
using Hommy.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.Users.Queries
{
    public record GetUsersQuery : IQuery<UserModel[]>
    {
    }

    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, UserModel[]>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        private IReadRepository<User> _userRepository;


        public GetUsersQueryHandler(DbContext dbContext, IMapper mapper, IReadRepository<User> userRepositry)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userRepository = userRepositry;
        }

        public async Task<Result<UserModel[]>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var isMaleSpec = new ExpressionSpecification<UserModel>(x => x.Gender == Gender.Male);

            var isFrom21CenterySpec = new ExpressionSpecification<UserModel>(x => x.DateOfBirth.Year > 2000);

            var isInactiveSpec = new ExpressionSpecification<UserModel>(x => x.Status == UserStatus.Inactive);

            var spec = (isInactiveSpec || isMaleSpec) && isFrom21CenterySpec;

            var result = await _userRepository.Query().ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToArrayAsync();

            result = result.Where(spec.IsSatisfiedBy).ToArray();

            return result;
        }
    }
}
