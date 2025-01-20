using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.Repositories.Interfaces;
using CustomerManagement.EmployeeManagement.Models.Domain;
using EmployeeManagement.Data;

namespace EmployeeManagement.Models.Repositories.Implemintations
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _dbContext; //to use instance from this class

        public SqlEmployeeRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IList<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
           var employee= _dbContext.Employees.Find(id);
            return employee;
        }
        public Employee Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
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
    }
}
