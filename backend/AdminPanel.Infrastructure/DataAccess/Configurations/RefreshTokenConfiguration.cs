using AdminPanel.Domain.Accounts;
using AdminPanel.Domain.RefreshTokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(r => r.Value)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(r => r.ExpirationDate)
            .IsRequired();
        
        builder.Property(r => r.IsActive)
            .IsRequired();
        
        builder.HasOne<Account>()
            .WithOne()
            .HasForeignKey<RefreshToken>(x => x.AccountId);
    }
}