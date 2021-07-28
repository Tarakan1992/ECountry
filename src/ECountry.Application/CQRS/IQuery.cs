using Hommy.ResultModel;
using MediatR;

namespace ECountry.Application.CQRS
{
    public interface IQuery<TOut> : IRequest<Result<TOut>>
    {
    }

    public interface IQueryHandler<TIn, TOut> : IRequestHandler<TIn, Result<TOut>>
        where TIn : IQuery<TOut>
    {
    }
}
