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

            string fullName = string.Empty;
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                fullName = string.Format(format, firstName, lastName);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    fullName = firstName;
                }

                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    fullName = lastName;
                }
            }

            return fullName;
        }
    }
}
