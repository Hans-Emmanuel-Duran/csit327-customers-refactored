using Customers.Contexts;
using Customers.Models;

namespace Customers.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);  
            _context.SaveChanges();
        }
        public void Update(Customer customer, Customer updatedCustomer)
        {
            customer.Name = updatedCustomer.Name;
            customer.Age = updatedCustomer.Age;
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

    }
}
