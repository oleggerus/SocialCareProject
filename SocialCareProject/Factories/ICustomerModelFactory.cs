using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DataRepository;
using DataRepository.Entities.People;
using SocialCareProject.Areas.Administration.Models;
using SocialCareProject.Areas.Customer.Models.Customer;

namespace SocialCareProject.Factories
{
    public interface ICustomerModelFactory
    {
        CustomerModel PrepareCustomerModel(Customer customer);

        WorkerItemModel PrepareWorkerItemModel(Worker worker);

        WorkerListViewModel PrepareWorkersListViewModel(IPagedList<Worker> workers);

        PeopleListViewModel PreparePeopleListViewModel(IPagedList<Customer> customers);

        CareRequestModel PrepareCareRequestModel(CareRequest request);
        CareRequestsListModel PrepareCareRequestsListModel(IPagedList<CareRequest> requests);
    }
}