using EmployeeManagement.Models.Domain;

namespace EmployeeManagement.Models.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IList<Employee> GetAll();
        Employee Add(Employee employee);
        bool Edit(Employee employee);
        bool Delete(int id);
    }
}
