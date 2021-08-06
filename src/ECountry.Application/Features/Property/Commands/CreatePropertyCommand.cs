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
    public record CreatePropertyCommand(string Name, PropertyType Type) : ICommand;

    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
        }
    }

    public class CreatePropertyCommandHandler : ICommandHandler<CreatePropertyCommand>
    {
        private readonly DbContext _dbContext;

        public CreatePropertyCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            if(await _dbContext.Set<Property>().AnyAsync(f => f.Name == request.Name))
            {
                return Result.Fail($"'Property' with name: '{request.Name}' already exists");
            }

            var field = new Property(request.Name, request.Type);
            
            await _dbContext.Set<Property>().AddAsync(field);

            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
