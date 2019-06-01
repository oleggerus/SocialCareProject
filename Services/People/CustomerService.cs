﻿using System;
using System.Linq;
using DataRepository;
using DataRepository.Entities;
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
        private readonly IRepository<WorkerPersonAssignment> _assignmentRepository;


        public CustomerService(IRepository<Customer> customerRepository,
            IRepository<CareRequest> careRequestRepository,
            IRepository<Worker> workerRepository,
                IRepository<WorkerPersonAssignment> assignmentRepository)
        {
            _customerRepository = customerRepository;
            _workerRepository = workerRepository;
            _assignmentRepository = assignmentRepository;
            _careRequestRepository = careRequestRepository;
        }



        public IPagedList<Customer> GetFilteredCustomers(int administrationId, string name, string phone, string email, int? statusId = null, int pageIndex = default(int),
            int pageSize = int.MaxValue)
        {
            var query = _customerRepository.TableNoTracking.Where(x => x.AdministrationId == administrationId);

            if (!string.IsNullOrWhiteSpace(name))
            {
                var tName = name.Trim().ToLower();
                query = query.Where(x => x.User.FirstName.ToLower().Contains(tName) || x.User.LastName.ToLower().Contains(tName));
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                var tPhone = phone.Trim().ToLower();
                query = query.Where(x => x.User.Phone.ToLower().Contains(tPhone));
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                var tEmail = email.Trim().ToLower();
                query = query.Where(x => x.User.Email.ToLower().Contains(tEmail));
            }
            if (statusId.HasValue)
            {
                query = query.Where(x => x.StatusId == statusId.Value);
            }

            return new PagedList<Customer>(query.OrderBy(x => x.User.LastName), pageIndex,
                pageSize);
        }
        public IPagedList<Worker> GetFilteredWorkers(int administrationId, int pageIndex = default(int),
            int pageSize = int.MaxValue)
        {
            var query = _workerRepository.TableNoTracking.Where(x =>
                x.Administration.Id == administrationId && x.PositionId == default(int));

            return new PagedList<Worker>(query.OrderBy(x => x.User.LastName), pageIndex,
                pageSize);
        }


        #region CRUD

        public Customer Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            _customerRepository.Insert(customer);

            return customer;
        }

        public Customer Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException();
            }
            _customerRepository.Update(customer);

            return customer;
        }


        public WorkerPersonAssignment InsertAssignment(WorkerPersonAssignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException();
            }
            _assignmentRepository.Insert(assignment);

            return assignment;
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
