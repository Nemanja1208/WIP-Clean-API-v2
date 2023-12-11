using Domain.Shared.Validations;

namespace Application.Abstractions
{
    public interface IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<Result<TResponse>>
    {
        Task<Result<TResponse>> Handle(TQuery query);
    }
}
