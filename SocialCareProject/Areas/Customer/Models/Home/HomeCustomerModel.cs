using SocialCareProject.Models;
using System.Collections.Generic;

namespace SocialCareProject.Areas.Customer.Models.Home
{
    public class HomeCustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NotificationCountModel
    {
        public int Number { get; set; }
        public IList<NotificationVewModel> Notifications { get; set; }
    }

    public class NotificationVewModel
    {
        public bool IsPositive { get; set; }
        public string CreatedOnUtc { get; set; }
        public bool IsOpened { get; set; }
        public string Text { get; set; }
    }
    public class NotificationListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<NotificationVewModel> Notifications { get; set; } = new List<NotificationVewModel>();
    }




}