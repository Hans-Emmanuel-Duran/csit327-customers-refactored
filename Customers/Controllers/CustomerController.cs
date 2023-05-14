using Customers.Contexts;
using Customers.Dto;
using Customers.Models;
using Customers.Repositories;
using Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customers.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{

		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		// GET: api/<CustomerController>
		[HttpGet]
		public IActionResult GetAllCustomers()
		{
			var customers = _customerService.GetAllCustomers();
			if (customers.Any())
				return Ok(customers);
			else
				return NoContent();
		}

		// GET api/<CustomerController>/5
		[HttpGet("{id}")]
		public IActionResult GetCustomer(int id)
		{
			var desiredCustomer = _customerService.GetCustomerById(id);

			if (desiredCustomer != null)
				return Ok(desiredCustomer);
			else
				return NotFound(); 
		}

		// POST api/<CustomerController>
		[HttpPost]
		public IActionResult CreateCustomer([FromBody] CreateCustomerDto customer)
		{
			if (customer == null)
				return BadRequest();

			try
			{
				_customerService.CreateCustomer(customer);
			} catch
			{
				return BadRequest($"Customer {customer.Name} already exists");
			}

			return Ok(customer);
		}

		// PUT api/<CustomerController>/5
		[HttpPut("{id}")]
		public IActionResult UpdateCustomer([FromBody] CustomerDto customer)
		{
			if (customer == null)
				return BadRequest();

			var updatedOrCreatedCustomer = _customerService.UpdateCustomer(customer);

			return Ok(updatedOrCreatedCustomer);
		}

		// DELETE api/<CustomerController>/5
		[HttpDelete("{id}")]
		public IActionResult DeleteCustomer(int id)
		{
			try
			{
				_customerService.DeleteCustomer(id);
			} catch (Exception ex)
			{
				return NotFound(ex.Message);
			}

			return NoContent();
		}
	}
}
