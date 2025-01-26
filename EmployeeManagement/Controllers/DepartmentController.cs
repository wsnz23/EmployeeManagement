using AutoMapper;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

    
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
       
            var departments = await _unitOfWork.Departments.GetAll();

         
            var results = _mapper.Map<IList<Department>>(departments);

          
            return Ok(results);
        }
    }
}
