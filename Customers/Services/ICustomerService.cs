using Customers.Dto;
using Customers.Models;

namespace Customers.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto GetCustomerById(int id);
        void CreateCustomer(CreateCustomerDto customer);
        CustomerDto UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(int id);


    }
}
