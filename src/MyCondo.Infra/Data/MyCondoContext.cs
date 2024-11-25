using Microsoft.EntityFrameworkCore;

namespace MyCondo.Infra.Data;

public class MyCondoContext : DbContext
{
    public MyCondoContext(DbContextOptions<MyCondoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyCondoContext).Assembly);
    }
}
