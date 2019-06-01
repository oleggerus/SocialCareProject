using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Models
{
    public class WorkerItemModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public int WorkerId{ get; set; }
        public byte[] Avatar{ get; set; }
        public string Status { get; set; }
        public bool IsFree { get; set; }
    }

    public class WorkerListViewModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<WorkerItemModel> Workers { get; set; } = new List<WorkerItemModel>();
    }
}