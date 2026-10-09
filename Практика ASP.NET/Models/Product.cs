using System.Data;
using System.Data.SqlClient;


namespace Практика_ASP.NET.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price, decimal weight)
        {
            Id = id;
            Name = name;
            Price = price;
            Weight = weight;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }
    }
}
