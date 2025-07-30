using Forshen.ERP.ProductManagement.Cli;
using Forshen.ERP.ProductManagement.Infrastructure;

Console.WriteLine("Hello, World!");

await using var dbContext = new AppDbContextFactory().CreateDbContext([]);

var app = new App(dbContext);
await app.Run();