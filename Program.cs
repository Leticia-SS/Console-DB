using consoleDB.Data;
using consoleDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var connectionString = config.GetConnectionString("WiredBrain");

GetProductADONET();
void GetProductADONET()
{
    var products = new List<Product>();

    using var connection = new SqlConnection(connectionString); // Se fosse oracle ou posgre teria que baixqar extensão
    connection.Open();

    string query = @"SELECT Id, Name, Description, ShortDescription, Price, ImageFile, Created, Category FROM Products";
    
    using var command = new SqlCommand(query, connection);

    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        var product = new Product
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.GetString(2),
            ShortDescription = reader.GetString(3),
            Price = reader.GetDecimal(4),
            ImageFile = reader.IsDBNull(5) ? null: reader.GetString(5),
            Created = reader.GetDateTime(6),
            Category = reader.GetString(7),
        };

        products.Add(product);
    }

    foreach (var product in products)
    {
        Console.WriteLine($"[{product.Id}] {product.Name} - {product.Price}");
    }
}


void GetProductEF()
{
    using var context = new AppDbContext(connectionString);

    var lstProducts = context.Products.ToList();

    foreach (var product in lstProducts)
    {
        Console.WriteLine($"[{product.Id}] {product.Name} - {product.Price}");
    }

}


Console.ReadKey();