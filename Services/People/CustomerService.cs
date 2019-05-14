using System;
using System.Linq;
using DataRepository;
using DataRepository.Entities.People;
using DataRepository.Enums;
using DataRepository.RepositoryPattern;

namespace Services.People
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<CareRequest> _careRequestRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Worker> _workerRepository;

        public CustomerService(IRepository<Customer> customerRepository,
            IRepository<CareRequest> careRequestRepository,
            IRepository<Worker> workerRepository)
        {
            _customerRepository = customerRepository;
            _workerRepository = workerRepository;
            _careRequestRepository = careRequestRepository;
        }

        #region CRUD


        public IPagedList<Customer> GetFilteredCustomers(int administrationId, int pageIndex = default(int),
            int pageSize = int.MaxValue)
        {
            var query = _customerRepository.TableNoTracking.Where(x => x.AdministrationId == administrationId);

            return new PagedList<Customer>(query.OrderBy(x => x.User.LastName), pageIndex,
                pageSize);
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

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomerByUserId(int id)
        {
            return _customerRepository.TableNoTracking.SingleOrDefault(x => x.UserId == id);
        }

        public Worker GetWorkerByUserId(int id)
        {
            return _workerRepository.TableNoTracking.SingleOrDefault(x => x.UserId == id);
        }
        #endregion


        #region Care requests

        public CareRequest GetCareRequestById(int id)
        {
            return _careRequestRepository.GetById(id);
        }

        public CareRequest InsertCareRequest(CareRequest careRequest)
        {
            if (careRequest == null)
            {
                throw new ArgumentNullException();
            }
            _careRequestRepository.Insert(careRequest);

            return careRequest;
        }

        public CareRequest UpdateCareRequest(CareRequest careRequest)
        {
            _careRequestRepository.Update(careRequest);

            return careRequest;
        }

        public bool CanCreateCareRequest(int personId)
        {
            var customer = GetCustomerById(personId);

            if (customer.StatusId != (int)CustomerCareStatuses.НеПотребуєДогляду)
            {
                return false;
            }

            if (_careRequestRepository.TableNoTracking.Any(x => x.CustomerId == personId && x.StatusId == (int)CareRequestStatuses.Opened))
            {
                return false;
            }

            return true;
        }

        public IPagedList<CareRequest> GetFilteredCareRequests(int administrationId, int pageIndex = default(int),
            int pageSize = int.MaxValue)
        {
            var query = _careRequestRepository.TableNoTracking.Where(x => x.Customer.AdministrationId == administrationId);

            return new PagedList<CareRequest>(query.OrderBy(x => x.CreatedOnUtc), pageIndex,
                pageSize);
        }


        #endregion

    }
}
