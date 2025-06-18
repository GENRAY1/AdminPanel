using AdminPanel.Domain.Clients;

namespace AdminPanel.Infrastructure.DataAccess.SeedingData;

public class ClientSeedingData
{
    public static readonly Client[] Data =
    [
        new Client
        {
            Id = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3"),
            Name = "Иван Петров",
            Email = "ivan.petrov@example.com",
            CreatedAt = DateTime.SpecifyKind(new DateTime(2022, 03, 01), DateTimeKind.Utc),
            Balance = 500000.11m
        },
        new Client
        {
            Id = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89"),
            Name = "ООО 'Глобал Инвест'",
            Email = "contact@globalinvest.ru",
            CreatedAt = DateTime.SpecifyKind(new DateTime(2023, 05, 21), DateTimeKind.Utc),
            UpdatedAt = DateTime.SpecifyKind(new DateTime(2024, 01, 02), DateTimeKind.Utc),
            Balance = 100000
        },
        new Client
        {
            Id = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E"),
            Name = "ООО 'Рога и Копыта'",
            Email = "contact@rogakopyta.ru",
            CreatedAt = DateTime.SpecifyKind(new DateTime(2021, 05, 23), DateTimeKind.Utc),
            UpdatedAt = DateTime.SpecifyKind(new DateTime(2025, 03, 24), DateTimeKind.Utc),
            Balance = 200000
        }
    ];
}