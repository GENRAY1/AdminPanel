using AdminPanel.Domain.Rates;

namespace AdminPanel.Infrastructure.DataAccess.SeedingData;

public class RateSeedingData
{
    public static IEnumerable<Rate> Data { get; } = [
        new Rate { Id = new Guid("AF9EE87C-C49C-4935-95AF-FDBF850BC455"), Value = 201, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 6, 01), DateTimeKind.Utc)},
        new Rate { Id = new Guid("AECAE947-96FA-4891-8FC1-6CDEF3C8B8BF"), Value = 179, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 5, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("1224C302-D8CE-4BF6-BF0F-C8FDCE929F67"), Value = 113, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 4, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("376A4FB5-9A56-458F-B6DC-82F9879ABF1E"), Value = 120, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("C96FD987-8F25-4CD3-AF6E-45E9FA7F4C0C"), Value = 140, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 2, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("1C418E7A-9D11-4F65-BCA1-F193C1EB5A6C"), Value = 109, CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("AD092827-B3D3-4971-B1A0-0CB7E93C733F"), Value = 51, CreatedAt = DateTime.SpecifyKind(new DateTime(2024, 12, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("F704312B-9DA0-48EE-BD0B-A90A4D1C7644"), Value = 94, CreatedAt = DateTime.SpecifyKind(new DateTime(2024, 11, 01), DateTimeKind.Utc)},
        new Rate { Id = new Guid("000FE0DC-5C77-4F7D-A97A-337D54BF34FA"), Value = 86, CreatedAt = DateTime.SpecifyKind(new DateTime(2024, 10, 01), DateTimeKind.Utc) },
        new Rate { Id = new Guid("D7A8B7EA-D0CA-468A-8D1C-FF421EB15463"), Value = 100, CreatedAt = DateTime.SpecifyKind(new DateTime(2024, 9, 01), DateTimeKind.Utc) }
    ];
}
