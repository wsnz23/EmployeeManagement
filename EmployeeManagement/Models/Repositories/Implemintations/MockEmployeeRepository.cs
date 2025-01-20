using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.Repositories.Interfaces;


namespace EmployeeManagement.Models.Repositories.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
                new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
                new Employee() { Id = 4, Name = "Ali", Department = "IT", Email = "Ali@pragimtech.com" },
            };
        }

        public Employee Add(Employee employee)
        {
            _employees.Add(employee);
            return employee;
        }

        public IList<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.Find(emp => emp.Id == id);
        }

        public bool Edit(Employee employee)
        {
            var emp = _employees.Find(emp => emp.Id == employee.Id);
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
                return true;
           
        }

        public bool Delete(int id)
        {
            var emp = _employees.Find(x => x.Id == id);
                _employees.Remove(emp);
                return true;
        }
    }
}
