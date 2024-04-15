using Microsoft.EntityFrameworkCore;

namespace TemporalTableInEF;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=DESKTOP-TVCSFN3\\MHA;Database=iCodeNext;Trusted_Connection=True;Encrypt=false";

        optionsBuilder.UseSqlServer(connectionString)
                      .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
                    .ToTable("Orders", t => t.IsTemporal(x => {
                        x.HasPeriodEnd("ValidTo");
                        x.HasPeriodStart("ValidFrom");
                        x.UseHistoryTable("OrderHistoricalData");
                    }));
    }
}

public class Order
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public int TotalPrice { get; set; }
}