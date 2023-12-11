using Domain.Shared.Validations;
namespace Application.Abstractions
{
    public interface ICommandHandler<TCommand>
    where TCommand : ICommand
    {
        Task<Result> Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        Task<Result<TResponse>> Handle(TCommand command);
    }
}
