using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository;
using DataRepository.Entities.People;

namespace Services.People
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);


        Customer GetCustomerById(int id);
        Customer GetCustomerByUserId(int id);
        Worker GetWorkerByUserId(int id);
       IPagedList<Customer> GetFilteredCustomers(int customerId, int pageIndex = default(int), int pageSize = int.MaxValue);

       IPagedList<Worker> GetFilteredWorkers(int customerId, int pageIndex = default(int), int pageSize = int.MaxValue);


        #region Care Requests

        CareRequest InsertCareRequest(CareRequest careRequest);
        CareRequest GetCareRequestById(int id);
        CareRequest UpdateCareRequest(CareRequest careRequest);
        bool CanCreateCareRequest(int personId);

        IPagedList<CareRequest> GetFilteredCareRequests(int administrationId, int pageIndex = default(int), int pageSize = int.MaxValue);

        #endregion
    }
}
