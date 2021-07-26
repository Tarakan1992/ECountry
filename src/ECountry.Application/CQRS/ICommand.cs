using Hommy.ResultModel;
using MediatR;

namespace ECountry.Application.CQRS
{
    public interface ICommand<TOut> : IRequest<Result<TOut>>
    {
    }

    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommandHandler<TIn, TOut> : IRequestHandler<TIn, Result<TOut>>
    where TIn : ICommand<TOut>
    {
    }

    public interface ICommandHandler<TIn> : IRequestHandler<TIn, Result>
        where TIn : ICommand
    {
    }
}
