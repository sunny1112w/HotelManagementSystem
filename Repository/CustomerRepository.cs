using BusinessObjects.Models;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public CustomerRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerFullName = customer.CustomerFullName;
                existingCustomer.Telephone = customer.Telephone;
                existingCustomer.EmailAddress = customer.EmailAddress;
                existingCustomer.CustomerBirthday = customer.CustomerBirthday;
                existingCustomer.CustomerStatus = customer.CustomerStatus;
                existingCustomer.Password = customer.Password;

                _context.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                customer.CustomerStatus = 0;
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerByEmailAndPassword(string email, string password)
        {
            Customer customer = _context.Customers.FirstOrDefault(c => c.EmailAddress == email && c.Password == password);
            return customer;
        }
    }
}
