using AdminPanel.Domain.Clients;
using AdminPanel.Infrastructure.DataAccess.SeedingData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.Balance)
            .IsRequired();
        
        builder.HasMany(x => x.Tags)
            .WithOne()
            .HasForeignKey(x => x.ClientId);
        
        builder.HasData(ClientSeedingData.Data);
    }
}