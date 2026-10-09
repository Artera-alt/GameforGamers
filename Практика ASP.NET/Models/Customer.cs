namespace Практика_ASP.NET.Models
{
    public class Customer
    {
        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        private int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
