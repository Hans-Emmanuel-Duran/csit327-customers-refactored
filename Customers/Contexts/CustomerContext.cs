using Microsoft.EntityFrameworkCore;
using Customers.Models;

namespace Customers.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
