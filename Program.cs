using consoleDB.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("WiredBrain");

using var context = new AppDbContext(connectionString);

var lstProducts = context.Products.ToList();

foreach (var product in lstProducts)
{
    Console.WriteLine($"[{product.Id}] {product.Name} - {product.Price}");
}

Console.ReadKey();