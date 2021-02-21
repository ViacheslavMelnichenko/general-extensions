using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace General.Extensions
{
    public static class EnumExtensions
    {
        public static string AggregateBy(this IEnumerable<string> strings, string delimiter)
        {
            var stringList = strings.ToList();
            return stringList.Any()
                ? stringList.Aggregate((current, next) => $"{current}{delimiter}{next}")
                : stringList.FirstOrDefault();
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var x in enumerable) action(x);
        }

        public static string GetEnumDescription(this Enum enumValue)
        {
            var enumValueAsString = enumValue.ToString();

            var type = enumValue.GetType();
            var fieldInfo = type.GetField(enumValueAsString);
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length <= 0) return enumValueAsString;
            var attribute = (DescriptionAttribute) attributes[0];
            return attribute.Description;
        }
    }
}