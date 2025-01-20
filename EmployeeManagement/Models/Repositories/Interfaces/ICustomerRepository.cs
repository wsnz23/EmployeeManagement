using CustomerManagement.EmployeeManagement.Models.Domain;

namespace CustomerManagement.EmployeeManagement.Models.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        IList<Customer> GetAll();
        bool Add(Customer customer);
        bool Edit(Customer customer);
        bool Delete(int id);
    }
}
