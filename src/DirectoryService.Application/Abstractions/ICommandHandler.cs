namespace DirectoryService.Application.Abstractions;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<Result<Errors>> Handle(TCommand command, CancellationToken token = default);
}

public interface ICommandHandler<TResponse, in TCommand>
    where TCommand : ICommand
{
    Task<Result<TResponse, Errors>> Handle(TCommand command, CancellationToken token = default);
}
