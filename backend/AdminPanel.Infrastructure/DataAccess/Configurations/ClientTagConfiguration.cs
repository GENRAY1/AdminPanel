using AdminPanel.Domain.Clients;
using AdminPanel.Infrastructure.DataAccess.SeedingData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanel.Infrastructure.DataAccess.Configurations;

public class ClientTagConfiguration : IEntityTypeConfiguration<ClientTag>
{
    public void Configure(EntityTypeBuilder<ClientTag> builder)
    {
        builder.HasKey(x => new {x.ClientId, x.Tag });

        builder.HasData(ClientTagsData.Data);
    }
}