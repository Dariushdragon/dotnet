using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using QueryProviderExample;
using QueryProviderExample.Benchmark;
using System.Diagnostics;

ApplicationDbContext context = new();


//var pid = Process.GetCurrentProcess().Id;
//for (int i = 0; i < 10000; i++)
//{
//    var secondQuery = context.Set<Product>()
//                        .OrderBy(x => x.Name)
//                        .ThenBy(x => x.Price)
//                        .AsNoTracking()
//                        .TagWith("This Is My Special Query :)")
//                        .ToList();
//}


//      --This Is My Special Query :)
//
//      SELECT [p].[Id], [p].[Name], [p].[Price]
//      FROM [Product] AS[p]
//      ORDER BY [p].[Name], [p].[Price]

BenchmarkRunner.Run(typeof(QueryBenchmark));