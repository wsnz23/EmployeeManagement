using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.Repositories.Interfaces;
using CustomerManagement.EmployeeManagement.Models.Domain;
using EmployeeManagement.Data;
using EmployeeManagement.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Migrations;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace EmployeeManagement.Models.Repositories.Implemintations
{
    
    public class SqlEmployeeRepository : IEmployeeRepository
    {
      
        private readonly AppDBContext _dbContext; //to use instance from this class
        private readonly IMapper _mapper;

        public SqlEmployeeRepository(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IList<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public EmployeeDTO GetById(int id)
        {
           var employee= _dbContext.Employees.Include(x=>x.Dept).FirstOrDefault(e=>e.Id==id);
            //var employeeDTO = EmpToDTO(employee);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }
        public Employee Add(EmployeeDTO employee)
        {
            //var emp = DTOToEmp(employee);
            var emp= _mapper.Map<Employee>(employee);
            _dbContext.Employees.Add(emp);
            _dbContext.SaveChanges();
            return emp;
        }

        public bool Delete(int id)
        {
            var emp = _dbContext.Employees.Find(id);
            if (emp != null) {
                _dbContext.Employees.Remove(emp);
                _dbContext.SaveChanges();
            }
            return true;
        }



        public bool Edit(Employee employee)
        {
            var emp = _dbContext.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }



        /*  public Employee GetByGender(string gender)
          {
            throw new NotImplementedException();
          }

          */
        private EmployeeDTO EmpToDTO(Employee employee)
        {
            var employeeDTO = new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Email = employee.Email,
                Salary = employee.Salary,
                DeptId = employee.DeptId,
                DeptName = employee.Dept.DepName

            };
            return employeeDTO;
        }

        private Employee DTOToEmp (EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                Id = employeeDTO.Id,
                Name = employeeDTO.Name,
                Address = employeeDTO.Address,
                Email = employeeDTO.Email,
                Salary = employeeDTO.Salary,
                DeptId = employeeDTO.DeptId,
    

            };
            return employee;
        }
    }
}
