using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Dtos;
using AdminPanel.Domain.Rates;

namespace AdminPanel.Application.Rates.GetCurrent;

public class GetCurrentRateQueryHandler(IRateRepository rateRepository)
    : IQueryHandler<GetCurrentRateQuery, RateDto?>
{
    public async Task<RateDto?> Handle(GetCurrentRateQuery request, CancellationToken cancellationToken)
    {
        Rate? rate =
            await rateRepository.GetCurrentAsync(cancellationToken);

        return rate is not null
            ? new RateDto
            {
                Id = rate.Id,
                CreatedAt = rate.CreatedAt,
                Value = rate.Value
            }
            : null;
    }
}