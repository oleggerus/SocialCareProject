using System;
using DataRepository.Entities.People;
using DataRepository.RepositoryPattern;

namespace Services.People
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            _customerRepository.Insert(customer);

            return customer;
        }
    }
}
