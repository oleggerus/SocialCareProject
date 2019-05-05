using System;
using System.Collections.Generic;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Models
{
    public class CareRequestsListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<CareRequestModel> Requests { get; set; } = new List<CareRequestModel>();
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
}