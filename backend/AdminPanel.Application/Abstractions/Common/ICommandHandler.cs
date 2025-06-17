namespace AdminPanel.Application.Abstractions.Common;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task Handle(TCommand request, CancellationToken cancellationToken);
}