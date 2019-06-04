using System;
using SocialCareProject.Models;
using System.Collections.Generic;

namespace SocialCareProject.Areas.Administration.Models
{
    public class CareRequestsListModel
    {
        public SimplePagerModel Pager { get; set; }

        public CareRequestFilterModel Filter { get; set; }

        public IList<CareRequestModel> Requests { get; set; } = new List<CareRequestModel>();
        //public IList<WorkerForAssignViewModel> Workers{ get; set; } = new List<WorkerForAssignViewModel>();
    }

    public class CareRequestModel
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Answer { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedOn { get; set; }
        public int StatusId { get; set; }
    }


    public class WorkerForAssignViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    public class CareRequestFilterModel
    {
        public int? StatusId { get; set; }
        public string Name { get; set; }
        public string StartDate{ get; set; }
        public string EndDate { get; set; }
    }
}