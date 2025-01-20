using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.Repositories.Interfaces;
using CustomerManagement.EmployeeManagement.Models.Domain;

namespace EmployeeManagement.Models.Repositories.Implemintations
{
    public class SqlmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public SqlmployeeRepository()
        {
            _employees = new List<Employee>()
                {
                    new Employee() { Id = 1, Name = "d", Department = "HR", Email = "mary@pragimtech.com" },
                    new Employee() { Id = 2, Name = "a", Department = "IT", Email = "john@pragimtech.com" },
                    new Employee() { Id = 3, Name = "w", Department = "IT", Email = "sam@pragimtech.com" },
                    new Employee() { Id = 4, Name = "b", Department = "IT", Email = "Ali@pragimtech.com" },
                };

        }

        public bool Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool EditCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)         
        {
            var emp = _employees.Find(emp => emp.Id == id);
            return emp;
        }
    }
}
