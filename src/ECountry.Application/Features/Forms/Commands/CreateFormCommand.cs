using ECountry.Application.CQRS;
using ECountry.Domain.Entities;
using FluentValidation;
using Hommy.Form;
using Hommy.ResultModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ECountry.Application.Features.Forms.Commands
{
    public record CreateFormCommand(string Name, string Description) : ICommand;

    public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
    {
        public CreateFormCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }

    public class CreateFormCommandHandler : ICommandHandler<CreateFormCommand>
    {
        private readonly DbContext _dbContext;

        public CreateFormCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            var definition = new FormDefinition(new RootElement()
            {
                Elements = new List<Element>()
                {
                    new InputElement("FirstName"),
                    new InputElement("LastName"),
                    new SelectElement("Gender")
                }
            });

            var form = new Form(request.Name, request.Description, definition);

            await _dbContext.Set<Form>().AddAsync(form);
            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}
