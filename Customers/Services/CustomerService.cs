using Customers.Dto;
using Customers.Models;
using Customers.Repositories;

namespace Customers.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _repository;

		public CustomerService(IRepository<Customer> repository)
		{
			_repository = repository;
		}
		public void CreateCustomer(CreateCustomerDto customerDto)
		{
			var customerHasSameName = _repository
				.GetAll().
				Where(c => c.Name.Equals(customerDto.Name)).
				FirstOrDefault() != null;

			if (customerHasSameName)
				throw new Exception($"Customer: {customerDto.Name} already exist.");

			var customerModel = new Customer
			{
				Name = customerDto.Name,
				Gender = customerDto.Gender,
				Address = customerDto.Address,
				Age = customerDto.Age
			};

			_repository.Create(customerModel);
		}

		public void DeleteCustomer(int id)
		{
            var desiredCustomer = _repository.Get(id);

            if (desiredCustomer == null)
                throw new Exception($"No customerDto with id {id} exists.");

			_repository.Delete(desiredCustomer);
        }

		public IEnumerable<CustomerDto> GetAllCustomers()
		{
			var customers = _repository.GetAll();
			return customers.Select(c => new CustomerDto
			{
				Id = c.Id,
				Name = c.Name,
				Gender = c.Gender,
				Age = c.Age,
				Address = c.Address,
			});
		}

		public CustomerDto GetCustomerById(int id)
		{
			var customerModel = _repository.Get(id);
			return new CustomerDto
			{
				Id = customerModel.Id,
				Name = customerModel.Name,
				Age = customerModel.Age,
				Address = customerModel.Address,
				Gender = customerModel.Gender,
			};
		}

		public CustomerDto UpdateCustomer(CustomerDto customerDto)
		{
            var desiredCustomer = _repository.Get(customerDto.Id);

            if (desiredCustomer == null)
            {
                _repository.Create(new Customer
				{
					Id = customerDto.Id,
					Name = customerDto.Name,
					Age = customerDto.Age,
					Address = customerDto.Address,
					Gender = customerDto.Gender,
				});
                return customerDto;
            }
            else
            {
                _repository.Update(desiredCustomer, new Customer
                {
                    Id = customerDto.Id,
                    Name = customerDto.Name,
                    Age = customerDto.Age,
                    Address = customerDto.Address,
                    Gender = customerDto.Gender,
                });
                return new CustomerDto
				{
					Id = desiredCustomer.Id,
					Name = desiredCustomer.Name,
					Age = customerDto.Age,
					Address = desiredCustomer.Address,
					Gender = desiredCustomer.Gender,
				};
            }
        }

    }
}
