using AdminPanel.Domain.Rates;
using AdminPanel.Infrastructure.DataAccess.SeedingData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt);

        builder.Property(x => x.Value);
        
        builder.HasIndex(x => x.CreatedAt);
        
        builder.HasData(RateSeedingData.Data);
    }
}