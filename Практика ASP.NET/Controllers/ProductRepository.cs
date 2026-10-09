using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using Практика_ASP.NET.Models;


namespace Практика_ASP.NET.Controllers
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(
                    "SELECT * FROM [dbo].[Product]", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    { 
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        decimal Price = reader.GetDecimal(2);
                        decimal Weight = reader.GetDecimal(3);
                        products.Add(new Product(Id,Name,Price,Weight));
                       
                    }
                }
            }

            return products;
        }
        public async Task<Product?> GetProductByIdAsync(int id,string name,decimal price, decimal weight)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand(
                    "SELECT * FROM [dbo].[Product] WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Product(id,name,price,weight)
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Weight = reader.GetDecimal(3)
                        };
                    }
                    return null;
                }
            }

        }

    }
}

