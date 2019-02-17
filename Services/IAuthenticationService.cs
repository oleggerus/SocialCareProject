using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities.People;
using DataRepository.Enums;

namespace Services
{
    public interface IAuthenticationService
    {
        void SignIn(User customer, bool createPersistentCookie);
        void SignOut();
        User GetAuthenticatedCustomer();
        
        UserValidationsStatuses ValidateUser(string email, string password);
        string CreateSaltKey(int length);
        string EncryptText(string plainText, string encryptionPrivateKey = "");        
    }
}
