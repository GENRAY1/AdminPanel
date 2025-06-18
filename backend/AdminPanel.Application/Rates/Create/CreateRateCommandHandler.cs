using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Domain.Rates;

namespace AdminPanel.Application.Rates.Create;

public class CreateRateCommandHandler(
    IRateRepository rateRepository
    ) : ICommandHandler<CreateRateCommand>
{
    public async Task Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        Rate rate = new Rate
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Value = request.Value
        };

        await rateRepository.AddAsync(rate, cancellationToken);
        await rateRepository.SaveAsync(cancellationToken);
    }
}