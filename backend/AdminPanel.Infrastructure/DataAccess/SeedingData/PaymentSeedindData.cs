using AdminPanel.Domain.Payments;

namespace AdminPanel.Infrastructure.DataAccess.SeedingData;

public class PaymentSeedindData
{
    public static readonly Payment[] Data =
    [
        new Payment
        {
            Id = new Guid("E71CA437-B0C9-4D84-9817-69A3FEDEBC17"),
            Amount = 1500.50m,
            CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 6, 10), DateTimeKind.Utc),
            ClientId = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3"), // Иван Петров
            RateId = new Guid("AF9EE87C-C49C-4935-95AF-FDBF850BC455"), // Курс 201 (июнь 2025)
        },
        new Payment
        {
            Id = new Guid("BB606C86-300B-4BCE-8D6A-D1DFFB29A588"),
            Amount = 2500,
            CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 5, 15), DateTimeKind.Utc),
            ClientId = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89"), // ООО 'Глобал Инвест'
            RateId = new Guid("AECAE947-96FA-4891-8FC1-6CDEF3C8B8BF"), // Курс 179 (май 2025)
        },
        new Payment
        {
            Id = new Guid("1F3B7D57-7C14-435B-998E-FA500424163A"),
            Amount = 18000,
            CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc),
            ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E"), // ООО 'Рога и Копыта'
            RateId = new Guid("1224C302-D8CE-4BF6-BF0F-C8FDCE929F67"), // Курс 113 (апрель 2025)
        },
        new Payment
        {
            Id = new Guid("74DFABAC-F7BC-4439-A501-DC148A65E94D"),
            Amount = 5000,
            CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 20), DateTimeKind.Utc),
            ClientId = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3"), // Иван Петров
            RateId = new Guid("376A4FB5-9A56-458F-B6DC-82F9879ABF1E"), // Курс 120 (март 2025)
        },
        new Payment
        {
            Id = new Guid("DFE99409-BF0F-444C-BF5D-BA7F7E82CFE1"),
            Amount = 100000,
            CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 2, 28), DateTimeKind.Utc),
            ClientId = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89"), // ООО 'Глобал Инвест'
            RateId = new Guid("C96FD987-8F25-4CD3-AF6E-45E9FA7F4C0C"), // Курс 140 (февраль 2025)
        }
    ];
}

