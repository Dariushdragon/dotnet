using Microsoft.EntityFrameworkCore;
using TemporalTableInEF;

ApplicationDbContext context = new();
//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

//context.AddRange(
//    new Order
//    {
//        Name = "Order Number 1",
//        Number = 1,
//        TotalPrice = 100_000
//    },
//    new Order
//    {
//        Name = "Order Number 2",
//        Number = 2,
//        TotalPrice = 200_000
//    },
//    new Order
//    {
//        Name = "Order Number 3",
//        Number = 3,
//        TotalPrice = 300_000
//    });

//context.SaveChanges();

//var order = context.Orders.Find(1);
//order.TotalPrice = 500000;
//context.SaveChanges();

//var order1 = context.Orders.Find(1);
//order1.TotalPrice = 700000;
//context.SaveChanges();


//TemporalAll
//var history = context
//    .Orders
//    .TemporalAll()
//    .Where(e => e.Id == 1)
//    .OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
//    .Select(
//        e => new
//        {
//            Orders = e,
//            ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
//            ValidTo = EF.Property<DateTime>(e, "ValidTo")
//        })
//    .ToList();


//var timeStamp2 = DateTime.Parse("2024-04-07 08:16:43.3623386");
//var timeStamp3 = DateTime.Parse("2024-04-07 08:16:43.4607627");

//var history = context
//    .Orders
//    .TemporalFromTo(timeStamp2, timeStamp3)
//    .Where(e => e.Id == 1)
//    .OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
//    .Select(
//        e => new
//        {
//            Employee = e,
//            ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
//            ValidTo = EF.Property<DateTime>(e, "ValidTo")
//        })
//    .ToList();




//var history_between = context
//    .Orders
//    .TemporalBetween(timeStamp2, timeStamp3)
//    .Where(e => e.Id == 1)
//    .OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
//    .Select(
//        e => new
//        {
//            Employee = e,
//            ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
//            ValidTo = EF.Property<DateTime>(e, "ValidTo")
//        })
//    .ToList();



//var timeStamp2 = DateTime.Parse("2024-04-05 08:02:03.1221641");
//var timeStamp3 = DateTime.UtcNow;

//var history = context
//    .Orders
//    .TemporalContainedIn(timeStamp2, timeStamp3)
//    .Where(e => e.Id == 1)
//    .OrderBy(e => EF.Property<DateTime>(e, "ValidFrom"))
//    .Select(
//        e => new
//        {
//            Employee = e,
//            ValidFrom = EF.Property<DateTime>(e, "ValidFrom"),
//            ValidTo = EF.Property<DateTime>(e, "ValidTo")
//        })
//    .ToList();



var timeStamp2 = DateTime.Parse("2024-04-07 08:16:43.4577641");
var history = context
    .Orders
    .TemporalAsOf(timeStamp2)
    .FirstOrDefault(e => e.Id == 1);

Console.ReadLine();