using DataRepository;
using DataRepository.Entities.People;
using DataRepository.Enums;
using DataRepository.Extensions;
using Services.Assignments;
using Services.People;
using SocialCareProject.Areas.Administration.Models;
using SocialCareProject.Areas.Customer.Models.Customer;
using System;
using System.Linq;

namespace SocialCareProject.Factories
{
    public class CustomerModelFactory : ICustomerModelFactory
    {
        private readonly ICustomerService _customerService;
        private readonly IWorkerService _workerService;
        private readonly IWorkerPersonAssignmentService _assignmentService;



        public CustomerModelFactory(ICustomerService customerService,
            IWorkerService workerService,
            IWorkerPersonAssignmentService assignmentService)
        {
            _customerService = customerService;
            _workerService = workerService;
            _assignmentService = assignmentService;
        }

        public CustomerModel PrepareCustomerModel(Customer customer)
        {
            var model = new CustomerModel
            {
                Id = customer.UserId,
                CustomerId = customer.Id,
                Administration = customer.Administration.Name,
                AdministrationContactName = customer.Administration.Contact.FirstName +
                                            " " + customer.Administration.Contact.LastName,
                AdministrationPhone = customer.Administration.Phone,
                StatusId = customer.StatusId,
                Email = customer.User.Email,
                Phone = customer.User.Phone,
                DateOfBirth = customer.User.DateOfBirth,
                MiddleName = customer.User.MiddleName,
                City = customer.Address.City,
                FirstName = customer.User.FirstName,
                Street = customer.Address.Street,
                LastName = customer.User.LastName,
                FullName = customer.User.GetFullName(),
                IsSelfPaid = customer.IsSelfPaid,
                RegionId = customer.Address.RegionId,
                ZipPostalCode = customer.Address.ZipPostalCode,
                HouseNameRoomNumber = customer.Address.HouseNameRoomNumber,
                IsInvalid = customer.IsInvalid,
                Avatar = customer.User.Avatar,
                Gender = customer.User.Gender,
                GenderName = Enum.GetName(typeof(GenderEnum), customer.User.Gender),
                HomePhoneNumber = customer.Address.PhoneNumber,
                Info = customer.Info,

            };
            return model;
        }

        public CareRequestModel PrepareCareRequestModel(CareRequest request)
        {
            var model = new CareRequestModel
            {
                Id = request.Id,
                CustomerId = request.CustomerId,
                CreatedOnUtc = request.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString),
                CustomerFullName = _customerService.GetCustomerById(request.CustomerId).User.GetFullName(),
                Reason = request.Reason,
                Answer = request.Answer,
                ReviewedOn = request.ReviewedOn.GetValueOrDefault().ToString(Constants.DateFormat.ShortDateString),
                StatusId = request.StatusId
            };
            if (request.ReviewedById.HasValue)
            {
                model.ReviewedBy = _workerService.GetWorkerById(request.ReviewedById.Value).User.GetFullName();
            }

            return model;
        }

        public PeopleListViewModel PreparePeopleListViewModel(IPagedList<Customer> customers)
        {
            return new PeopleListViewModel
            {
                People = customers.Select(PrepareCustomerModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(customers)
            };
        }

        public WorkerListViewModel PrepareWorkersListViewModel(IPagedList<Worker> workers)
        {
            return new WorkerListViewModel
            {
                Workers = workers.Select(PrepareWorkerItemModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(workers)
            };
        }

        public CareRequestsListModel PrepareCareRequestsListModel(IPagedList<CareRequest> requests)
        {
            return new CareRequestsListModel
            {
                Requests = requests.Select(PrepareCareRequestModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(requests)
            };
        }

        public WorkerItemModel PrepareWorkerItemModel(Worker worker)
        {

            var isFree = _assignmentService.IsWorkerFree(worker.UserId);
            return new WorkerItemModel
            {
                UserId = worker.UserId,
                FullName = worker.User.GetFullName(),
                WorkerId = worker.Id,
                Email = worker.User.Email,
                FirstName = worker.User.FirstName,
                LastName = worker.User.LastName,
                MiddleName = worker.User.MiddleName,
                Phone = worker.User.Phone,
                Avatar = worker.User.Avatar,
                IsFree = isFree,
                Status = isFree ? "Доступний" : "Зайнятий"
            };
        }
    }
}