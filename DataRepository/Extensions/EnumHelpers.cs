using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataRepository.Extensions
{
    public static class EnumHelpers
    {

        /// <summary>
        /// Returns the value of the Description attribute on the enum, otherwise an empty string. E.g. GetEnumDescription&lt;CustomerStatus&gt;((CustomerStatus)person.StatusId)
        /// </summary>
        /// <typeparam name="T">The Type of the enum</typeparam>
        /// <param name="value">The value of the enum</param>
        /// <returns>The description string from the DescriptionAttribute</returns>
        public static string GetEnumDescription<T>(T value)
        {
            var t = typeof(T);
            if (!t.IsEnum)
                throw new InvalidCastException("This method expects an enum type");

            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                if (attrs.Length > 0)
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the value of the EnumStringAttribute attribute on the enum, otherwise an empty string. E.g. GetEnumCustomStringAttribute&lt;CustomerStatus&gt;((CustomerStatus)person.StatusId)
        /// </summary>
        /// <typeparam name="T">The Type of the enum</typeparam>
        /// <param name="value">The value of the enum</param>
        /// <returns>The description string from the EnumStringAttribute</returns>
        

        /// <summary>
        /// Get localized list of key/value pairs for enum (applicable for KO select binding)
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="exclude">Arrays of TEnum values to exclude</param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetEnumKeyValuePairList<TEnum>(params TEnum[] exclude)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            if (exclude != null && exclude.Any())
            {
                enumValues = enumValues.Where(x => !exclude.Contains(x));
            }

            return enumValues
                .Select(x => new KeyValuePair<int, string>(x.ToInt32(CultureInfo.InvariantCulture), x.ToString()))
                .ToList();
        }

        /// <summary>
        /// Get localized list of SelectListItem for enum (applicable for razor select)
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="exclude">Arrays of TEnum values to exclude</param>
        /// <returns></returns>

        public static IList<KeyValuePair<Enum, string>> ToList<T>() where T : struct
        {
            var type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enum");
            }

            return (IList<KeyValuePair<Enum, string>>)
                Enum.GetValues(type)
                    .OfType<Enum>()
                    .Select(e => new KeyValuePair<Enum, string>(e, e.Description()))
                    .ToArray();
        }

        public static string Description(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])
                fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }

            return description;
        }


        public static IList<SelectListItem> GetEnumSelectListItemList<TEnum>(params TEnum[] exclude)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            if (exclude != null && exclude.Any())
            {
                enumValues = enumValues.Where(x => !exclude.Contains(x));
            }

            return enumValues
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = x.ToInt32(CultureInfo.InvariantCulture).ToString()
                }).ToList();
        }

        /// <summary>
        /// Get localized list of key/value pairs specified enum values
        /// </summary>
        /// <param name="include">values to get list of</param>
        /// <returns></returns>
        public static List<KeyValuePair<int, string>> GetEnumKeyValuePairListInclude<TEnum>(params TEnum[] include)
            where TEnum : struct, IConvertible
        {
            if (include.Any() && !include.First().GetType().IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return include.Select(x => new KeyValuePair<int, string>(x.ToInt32(CultureInfo.InvariantCulture), x.ToString())).ToList();
        }
    }
}
