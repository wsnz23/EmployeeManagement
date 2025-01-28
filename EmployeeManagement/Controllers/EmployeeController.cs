using AutoMapper;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;
using EmployeeManagement.Models.IRepository;
using EmployeeManagement.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<EmployeeController> logger, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // CRUD Operations for Employees

        // Get Employee by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await _unitOfWork.Employees.Get(e=>e.Id==id,include:q=>q.Include(e=>e.Dept));
            if(emp==null)
                return NotFound();
            var employeeDTO=_mapper.Map<EmployeeDTO>(emp);
            return Ok(employeeDTO);
        }

      
      [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
              try
    {
        var employees = await _unitOfWork.Employees.GetAll(include: q => q.Include(e => e.Dept));
        var employeeDTOs = _mapper.Map<List<EmployeeDTO>>(employees);
        return Ok(employeeDTOs);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error fetching all employees");
        return StatusCode(500, "Internal server error");
    }
       }

     //  Add a New Employee
     //  [HttpPost("AddEmployee")]
    //    public IActionResult Add([FromBody]EmployeeDTO employee)
    //    {
    //        var result = _employeeRepository.Add(employee);
    //        return Ok(result);
    //    }

    //    // Update an Employee
    //    [HttpPut("EditEmployee")]
    //    public IActionResult Edit(Employee employee)
    //    {
    //        var result = _employeeRepository.Edit(employee);
    //        return Ok(result);
    //    }

    //    // Delete an Employee
    //    [HttpDelete("DeleteEmployee/{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        var result = _employeeRepository.Delete(id);
    //        return Ok(result);
    //    }
    }
}
