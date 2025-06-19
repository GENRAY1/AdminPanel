using AdminPanel.Application.Abstractions.Common;
using AdminPanel.Application.Dtos;

namespace AdminPanel.Application.Rates.GetCurrent;

public record GetCurrentRateQuery: IQuery<RateDto?>;