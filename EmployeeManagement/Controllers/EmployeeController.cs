using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;
using EmployeeManagement.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // CRUD Operations for Employees

        // Get Employee by ID
        [HttpGet("GetEmployee/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetById(id);
            return Ok(emp);
        }

        // Get All Employees
        [HttpGet("GetAllEmployees")]
        public IActionResult GetAll()
        {
            var emp = _employeeRepository.GetAll();
            return Ok(emp);
        }

        // Add a New Employee
        [HttpPost("AddEmployee")]
        public IActionResult Add([FromBody]EmployeeDTO employee)
        {
            var result = _employeeRepository.Add(employee);
            return Ok(result);
        }

        // Update an Employee
        [HttpPut("EditEmployee")]
        public IActionResult Edit(Employee employee)
        {
            var result = _employeeRepository.Edit(employee);
            return Ok(result);
        }

        // Delete an Employee
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeRepository.Delete(id);
            return Ok(result);
        }
    }
}
