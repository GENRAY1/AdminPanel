using AdminPanel.Domain.Clients;

namespace AdminPanel.Infrastructure.DataAccess.SeedingData;

public class ClientTagsData
{
    public static readonly ClientTag[] Data =
    [
        new ClientTag { Tag = ClientTagEnum.Active, ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E") },
        new ClientTag { Tag = ClientTagEnum.Investor, ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E") },
        new ClientTag { Tag = ClientTagEnum.Vip, ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E") },
        new ClientTag { Tag = ClientTagEnum.HighRisk, ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E") },
        new ClientTag { Tag = ClientTagEnum.Margin, ClientId = new Guid("751150D4-8E8E-466F-AC7D-BEA47981281E") },
        new ClientTag { Tag = ClientTagEnum.Inactive, ClientId = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89") },
        new ClientTag { Tag = ClientTagEnum.Cash, ClientId = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89") },
        new ClientTag { Tag = ClientTagEnum.LowRisk, ClientId = new Guid("F33B8C2E-9335-419A-A1CA-85D6EB5F5C89") },
        new ClientTag { Tag = ClientTagEnum.Active, ClientId = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3") },
        new ClientTag { Tag = ClientTagEnum.Margin, ClientId = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3") },
        new ClientTag { Tag = ClientTagEnum.Vip, ClientId = new Guid("E3C4EA0E-3C29-4FFE-82A8-8E72857035F3") },
    ];
}