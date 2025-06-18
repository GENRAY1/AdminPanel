using AdminPanel.Domain.Payments;
using AdminPanel.Infrastructure.DataAccess.SeedingData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.CreatedAt);
        
        builder.Property(x => x.Amount);
        
        builder.HasIndex(x => x.CreatedAt);

        builder.HasOne(x => x.Rate)
            .WithMany()
            .HasForeignKey(x => x.RateId);
        
        builder.HasOne(x => x.Client)
            .WithMany()
            .HasForeignKey(x => x.ClientId);

        builder.HasData(PaymentSeedindData.Data);
    }
}