using AdminPanel.Application.Abstractions.Common;

namespace AdminPanel.Application.Rates.GetCurrent;

public record GetCurrentRateQuery: IQuery<RateDto?>;