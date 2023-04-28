using Microsoft.EntityFrameworkCore;
using Customers.Models;

namespace Customers.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
