using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;
using System.Collections.Generic;

namespace EmployeeManagement.Models.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        DepartmentDTO GetById(int id);
        IList<DepartmentDTO> GetAll();
        Department Add(DepartmentDTO department);
        bool Edit(Department department);
        bool Delete(int id);
    }
}
