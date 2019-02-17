using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using DataRepository;
using Services;
using SocialCareProject.Models;

namespace SocialCareProject.Extensions
{
    public static class Extensions
    {
        public static string ToTitleCase(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? str : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower(CultureInfo.InvariantCulture));
        }

        public static string ToCopyString(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            var regex = new Regex(@"(?<=Copy \()(.*?)(?=\))");
            var match = regex.Match(str);
            var number = 0;
            int.TryParse(match.Value, out number);
            number++;

            var position = str.IndexOf(match.Value, StringComparison.Ordinal);
            if (position <= 0)
            {
                return str.Insert(0, "Copy (1) - ");
            }

            return str.Remove(position, match.Value.Length).Insert(position, number.ToString());
        }

        public static SimplePagerModel ToSimplePagerModel<T>(IPagedList<T> items)
        {
            return new SimplePagerModel
            {
                PageSize = items.PageSize,
                TotalCount = items.TotalCount,
                TotalPages = items.TotalPages,
                HasNextPage = items.HasNextPage,
                HasPreviousPage = items.HasPreviousPage,
                PageIndex = items.PageIndex
            };

        }
    }

}