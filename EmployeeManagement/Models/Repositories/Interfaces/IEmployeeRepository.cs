using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;

namespace EmployeeManagement.Models.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        EmployeeDTO GetById(int id);
        IList<Employee> GetAll();
        Employee Add(EmployeeDTO employee);
        bool Edit(Employee employee);
        bool Delete(int id);
    }
}
