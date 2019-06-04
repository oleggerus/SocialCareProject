using System;
using DataRepository.Entities.People;

namespace DataRepository.Extensions
{
    public static class UserExtensions
    {
        public static string GetFullName(this User user, string format = Constants.NameFormat.Default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var middleName = user.MiddleName;

            var fullName = string.Empty;
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(middleName))
            {
                fullName = string.Format(format, firstName, lastName, middleName);
            }
            else
            {
                fullName = "";
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    fullName = fullName +  firstName + " ";
                }

                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    fullName = fullName + lastName + " ";
                }
                if (!string.IsNullOrWhiteSpace(middleName))
                {
                    fullName = fullName + middleName + " ";
                }

            }

            return fullName;
        }
    }
}
