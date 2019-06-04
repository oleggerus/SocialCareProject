namespace DataRepository
{
    public class Constants
    {
        public static class DateFormat
        {
            public const string LongDateString = "ddd d MMM yy";
            public const string LongDateTimeString = "ddd d MMM yy HH:mm";
            public const string ShortDateString = "d MMM yy";
            public const string ShortDateStringUS = "dd/MM/yyyy";
            public const string ShortDateStringFullMonth = "dd/MMM/yyyy";
            public const string DateOfBirthDBAttribute = "yyyy-MM-dd";
            public const string UIDateString = "{0:dd MMM yy}";
            public const string ShortDateTimeString = "DD/MM/YYYY HH:mm";
        }

        public static class TimeFormat
        {
            public const string ShortTimeString = "HH:mm";
        }

        public static class NameFormat
        {
            public const string Default = "{0} {1} {2}";
            public const string Alternative = "{1}, {0}";
        }

        public static class TempDataKey
        {
            public const string PostRedirectNotify = "PostRedirectNotify";
        }

        public static class Paging
        {
            public const int DefaultPageSize = 5;
            public const int BigPageSize = 10;
        }

        public static class RegexPatterns
        {
            public const string Phone = "^([0-9\\(\\)\\/\\+ \\-]*){1,30}$";
            public const string Letters = "^[a-zA-Z]*$";
            public const string Token = "%.*?%";
        }

        public static class UserSettings
        {
            public const int ActivationCodeExpirationTimeInMinutes = 30;
            public const int SaltKeyNumberOfSymbols = 16;
        }


        public static class FileAttachmentUploadParameters
        {
            public const int MaxFileSize = 6 * 1024 * 1024;
        }
    }
}
