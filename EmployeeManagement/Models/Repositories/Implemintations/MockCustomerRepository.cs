using CustomerManagement.EmployeeManagement.Models.Domain;
using CustomerManagement.EmployeeManagement.Models.Repositories.Interfaces;

namespace CustomerManagement.EmployeeManagement.Models.Repositories.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;

        public MockCustomerRepository()
        {
            _customers = new List<Customer>()
            {
          new Customer() { Id = 1, CustomerName = "Wasan", Email = "wasan@example.com", PhoneNumber = "0786100855", Address = "Amman" },
          new Customer() { Id = 2, CustomerName = "Hala", Email = "hala@example.com", PhoneNumber = "0786100844", Address = "Irbid" },
          new Customer() { Id = 3, CustomerName = "Zeina", Email = "zeina@example.com", PhoneNumber = "0786100822", Address = "Zarqa" }

            };
        }

        // Implementing GetById method
        public Customer GetById(int id)
        {
            return _customers.Find(cust => cust.Id == id);
        }

        // Get all customers
        public IList<Customer> GetAll()
        {
            return _customers;
        }

        // Add a new customer
        public bool Add(Customer customer)
        {
            _customers.Add(customer);
            return true;
        }

        // Edit an existing customer
        public bool Edit(Customer customer)
        {
            var existingCustomer = _customers.Find(cust => cust.Id == customer.Id);
            if (existingCustomer == null) return false;

            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.Address = customer.Address;
            return true;
        }

        // Delete a customer by ID
        public bool Delete(int id)
        {
            var customer = _customers.Find(cust => cust.Id == id);
            if (customer == null) return false;

            _customers.Remove(customer);
            return true;
        }
    }
}
