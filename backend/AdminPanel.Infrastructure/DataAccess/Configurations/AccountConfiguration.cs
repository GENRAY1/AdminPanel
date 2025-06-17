using AdminPanel.Domain.Accounts;
using AdminPanel.Infrastructure.DataAccess.SeedingData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasData(AccountSeedingData.Accounts);
    }
}