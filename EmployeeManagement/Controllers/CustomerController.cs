using CustomerManagement.EmployeeManagement.Models.Domain;
using CustomerManagement.EmployeeManagement.Models.Repositories.Interfaces;
using EmployeeManagement.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // CRUD Operations for Customers

        // Get Customer by ID
        [HttpGet("GetCustomer/{id}")]
        public IActionResult GetById(int id)
        {
            var cust = _customerRepository.GetById(id);
            return Ok(cust);
        }

        // Get All Customers
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var cust = _customerRepository.GetAll();
            return Ok(cust);
        }

        // Add a New Customer
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var cust = _customerRepository.Add(customer);
            return Ok(cust);
        }

        // Update a Customer
        [HttpPut("EditCustomer")]
        public IActionResult EditCustomer(Customer customer)
        {
            var cust = _customerRepository.Edit(customer);
            return Ok(cust);
        }

        // Delete a Customer
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var cust = _customerRepository.Delete(id);
            return Ok(cust);
        }
    }
}
