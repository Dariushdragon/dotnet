using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace QueryProviderExample;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=DESKTOP-TVCSFN3\\MHA;Database=iCodeNext;Trusted_Connection=True;Encrypt=false";

        optionsBuilder.UseSqlServer(connectionString);
                      //.LogTo(Console.WriteLine, LogLevel.Information);

    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public int Price { get; set; }
}