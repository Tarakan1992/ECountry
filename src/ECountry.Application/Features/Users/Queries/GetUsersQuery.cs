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
            var groups = await _dbContext.Set<Group>().ToListAsync();

            var user = await _dbContext.Set<User>().Include(x => x.Groups).FirstAsync(x => x.Id == 20);

            foreach(var group in groups)
            {
                user.AddGroup(group);
            }

            await _dbContext.SaveChangesAsync();

            user.AddGroup(new Group("Suck my dick"));

            await _dbContext.SaveChangesAsync();

            var result = await _userRepository.Query().ProjectTo<UserModel>(_mapper.ConfigurationProvider).ToArrayAsync();

            return result;
        }
    }
}
