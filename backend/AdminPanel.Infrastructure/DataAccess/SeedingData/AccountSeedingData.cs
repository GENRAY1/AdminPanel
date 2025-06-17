using AdminPanel.Domain.Accounts;

namespace AdminPanel.Infrastructure.DataAccess.SeedingData;

public class AccountSeedingData
{
    public static Account[] Accounts =
    [
        new Account{
            Id = new Guid("8B4B4145-6122-4D99-9D7B-E669112618FE"), 
            Email = "admin@mirra.dev", 
            Password = "$2a$11$..1tQa8qz03JlNsIgHn9ZOc2/iUEM5Y1RYCRbxcm0Y.B5wLV0ZCpO",
            CreatedAt = new DateTime(1,1,1)
        }
    ];
}