using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace QueryProviderExample.Benchmark;

[MemoryDiagnoser]
public class QueryBenchmark
{

    [Benchmark]
    public double LoadEntities()
    {
        var sum = 0;
        var count = 0;
        using var ctx = new ApplicationDbContext();
        foreach (var product in ctx.Product.Skip(100).ToList())
        {
            sum += product.Price;
            count++;
        }

        return (double)sum / count;
    }


    [Benchmark]
    public double LoadEntitiesNoTracking()
    {
        var sum = 0;
        var count = 0;
        using var ctx = new ApplicationDbContext();
        foreach (var product in ctx.Product.Skip(100).AsNoTracking().ToList())
        {
            sum += product.Price;
            count++;
        }

        return (double)sum / count;
    }


    [Benchmark]
    public double ProjectOnlyRanking()
    {
        var sum = 0;
        var count = 0;
        using var ctx = new ApplicationDbContext();
        foreach (var price in ctx.Product.Skip(100).Select(x => x.Price).ToList())
        {
            sum += price;
            count++;
        }

        return (double)sum / count;
    }

    [Benchmark(Baseline = true)]
    public double CalculateInDatabase()
    {
        using var ctx = new ApplicationDbContext();
        return ctx.Product.Skip(100).Average(b => b.Price);
    }
}
