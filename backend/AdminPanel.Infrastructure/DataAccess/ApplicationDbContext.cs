using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Infrastructure.DataAccess;

internal sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}