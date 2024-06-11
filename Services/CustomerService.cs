using BusinessObjects.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService(CustomerRepository customerRepository)
    {
        private readonly CustomerRepository _customerRepo = customerRepository;

        public IEnumerable<Customer> GetAllCucstomers()
        {
            IEnumerable<Customer> customers = _customerRepo.GetAllCustomers();
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepo.AddCustomer(customer);
        }

        public Customer GetCustomerByID(int id)
        {
            return _customerRepo.GetCustomerById(id);
        }

        public void DeleteCustmerByID(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepo.UpdateCustomer(customer);
        }

    }
}
