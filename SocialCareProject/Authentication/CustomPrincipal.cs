using System.Linq;
using System.Security.Principal;

namespace SocialCareProject.Authentication
{
    public class CustomUser: IPrincipal
    {
        #region Identity Properties

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(role.Contains);
        }

        public CustomUser(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}