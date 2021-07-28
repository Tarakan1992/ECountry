using ECountry.Application.CQRS;
using ECountry.Domain;
using ECountry.Domain.Entities;
using FluentValidation;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.Fields.Commands
{
    public record CreateFieldCommand : ICommand
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
    }

    public class CreateFieldCommandValidator : AbstractValidator<CreateFieldCommand>
    {
        public CreateFieldCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DataType).NotEmpty();
        }
    }

    public class CreateFieldCommandHandler : ICommandHandler<CreateFieldCommand>
    {
        private readonly DbContext _dbContext;

        public CreateFieldCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            if(await _dbContext.Set<Field>().AnyAsync(f => f.Name == request.Name))
            {
                return Result.Fail($"'Field' with name:{request.Name} already exists");
            }

            var field = new Field(request.Name, request.DataType);
            
            await _dbContext.Set<Field>().AddAsync(field);

            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
