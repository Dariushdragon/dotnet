﻿#nullable disable

//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using QueryProviderExample;
//using System.Transactions;

//var connection = "Server=DESKTOP-TVCSFN3\\MHA;Database=iCodeNext;Trusted_Connection=True;Encrypt=false";

//var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                           .UseSqlServer(connection)
//                           .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
//                           .EnableSensitiveDataLogging()
//                           .Options;

//ApplicationDbContext context = new(dbContextOptions);
//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

//context.Authors.Add(new Auther { Name = "Mohammad" });
//context.Authors.Add(new Auther { Name = "Mohammad_1" });

//context.SaveChanges();

//#
//context.Authors.Add(new Auther { Name = "Mohammad" });
//context.Authors.Add(new Auther { Name = "Mohammad_1111" });
//context.SaveChanges();

//#
//var auther = new Auther { Name = "Mohammad" };
//context.Authors.Add(auther);
//context.SaveChanges();
//context.Posts.Add(new Post { AutherId = auther.Id, Title = "C# Books" });
//context.SaveChanges();

//#
//var auther = new Auther { Name = "Mohammad" };
//context.Authors.Add(auther);
//context.SaveChanges();
//context.Posts.Add(new Post { AutherId = auther.Id, Title = "C# Books_123" });
//context.SaveChanges();


//#
//using var transaction = context.Database.BeginTransaction();
//try
//{

//	var auther = new Auther { Name = "Mohammad" };
//	context.Authors.Add(auther);
//	context.SaveChanges();
//	context.Posts.Add(new Post { AutherId = auther.Id, Title = "C# Books_123" });
//	context.SaveChanges();

//	transaction.Commit();
//}
//catch (Exception)
//{
//	transaction.Rollback();
//}

//#
//using var transaction = context.Database.BeginTransaction();
//var auther = new Auther { Name = "Mohammad" };
//var post = new Post { Title = "C# Books_123" };
//try
//{
//    context.Authors.Add(auther);
//    context.SaveChanges();

//    transaction.CreateSavepoint("Auther_Added");

//    post.AutherId = auther.Id;
//    context.Posts.Add(post);
//    context.SaveChanges();

//    transaction.Commit();
//}
//catch (Exception)
//{
//    post.Title = "C# New";
//    transaction.RollbackToSavepoint("Auther_Added");
//    context.Posts.Add(post);
//    context.SaveChanges();

//    transaction.Commit();
//}

//#
//using (var scope = new TransactionScope(
//           TransactionScopeOption.Required,
//           new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
//{
//    try
//    {
//        var auther = new Auther { Name = "Mohammad" };
//        context.Authors.Add(auther);
//        context.SaveChanges();

//        var post = new Post { AutherId = auther.Id, Title = "C# Books" };
//        context.Posts.Add(post);

//        context.SaveChanges();

//        scope.Complete();
//    }
//    catch (Exception e)
//    {

//    }
//}
//Console.ReadKey();






using System.ComponentModel.Design;

public class Program
{
    public static void Main(string[] args)
    {
        var key = Console.ReadLine();
        IPrintStrategy strategy = PrintFactory.GetInstance(key);
        strategy.Print();
    }
}

public static class PrintFactory
{
    public static IPrintStrategy GetInstance(string key)
    {
        if (key == "A" || key == "Z")
        {
            return new AStrategy();
        }
        else if (key == "B")
        {
            return new BStrategy();
        }
        else if (key == "C")
        {
            return new CStrategy();
        }
        else
        {
            return new DStrategy();
        }
    }
}

public interface IPrintStrategy
{
    void Print();
}

public class AStrategy : IPrintStrategy
{
    public void Print()
    {
        Console.WriteLine("AAA");
    }
}

public class BStrategy : IPrintStrategy
{
    public void Print()
    {
        Console.WriteLine("BBB");
    }
}

public class CStrategy : IPrintStrategy
{
    public void Print()
    {
        Console.WriteLine("CCC");
    }
}

public class DStrategy : IPrintStrategy
{
    public void Print()
    {
        Console.WriteLine("DDD");
    }
}