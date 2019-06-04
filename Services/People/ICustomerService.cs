using System;
using DataRepository;
using DataRepository.Entities;
using DataRepository.Entities.People;
using System.Collections.Generic;

namespace Services.People
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);

        Notification UpdateNotification(Notification notification);
        Customer GetCustomerById(int id);
        Customer GetCustomerByUserId(int id);
        Worker GetWorkerByUserId(int id);

        WorkerPersonAssignment InsertAssignment(WorkerPersonAssignment assignment);
        IPagedList<Customer> GetFilteredCustomers(int administrationId, string name, string phone, string email, int? statusId = null, int pageIndex = default(int), int pageSize = int.MaxValue);

        IPagedList<Worker> GetFilteredWorkers(int administrationId, int pageIndex = default(int), int pageSize = int.MaxValue);

        Notification InsertNotification(Notification notification);
        List<Notification> GetNotifications(int userId);
        Notification GetNotificationById(int id);

        IPagedList<Notification> GetPagedNotifications(int userId, int pageIndex = default(int),
            int pageSize = int.MaxValue);
        #region Care Requests

        CareRequest InsertCareRequest(CareRequest careRequest);
        CareRequest GetCareRequestById(int id);
        CareRequest UpdateCareRequest(CareRequest careRequest);
        bool CanCreateCareRequest(int personId);

        IPagedList<CareRequest> GetFilteredCareRequests(int administrationId, string name, DateTime? startDate,
            DateTime? endDate, int? statusId = null,
            int pageIndex = default(int), int pageSize = int.MaxValue);

        #endregion
    }
}
