using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace General.Extensions
{
    public static class StringExtensions
    {
        public static bool CaseInsensitiveContains(this string @string, string substring)
        {
            if (string.IsNullOrEmpty(@string)) return false;
            return @string.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static T ConvertTo<T>(this string @string)
        {
            return (T) Convert.ChangeType(@string, typeof(T));
        }

        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }

        public static double ParseToDouble(this string @string)
        {
            return double.Parse(@string.Replace(',', '.'));
        }

        public static List<T> ParseToList<T>(this string @string, string separator = ",")
        {
            var stringArray = !@string.IsNullOrEmpty()
                ? @string.Split(new[] {separator}, StringSplitOptions.None)
                    .Select(x => x.Trim()).ToArray()
                : null;

            return stringArray?.Select(x => x.ConvertTo<T>()).ToList() ?? new List<T>();
        }

        public static string Remove(this string @string, params string[] partsToRemove)
        {
            partsToRemove.ForEach(p => @string = @string.Replace(p, ""));
            return @string;
        }

        public static string RemoveFormatting(this string @string)
        {
            if (@string.IsNullOrEmpty())
                return @string;
            if (@string.Contains(" ") || @string.Contains("&nbsp;") || @string.Contains(" "))
                @string = @string.Remove(" ", "&nbsp;", " ");
            if (@string.Contains(","))
                @string = @string.Remove(",");
            return @string;
        }

        public static string RemoveNotLetters(this string @string)
        {
            return string.Join("", @string.ToCharArray().Where(char.IsLetter).ToArray());
        }

        public static string RemoveNotDigits(this string @string)
        {
            return string.IsNullOrEmpty(@string)
                ? string.Empty
                : string.Join("", @string.ToCharArray().Where(char.IsDigit).ToArray());
        }

        public static string RemoveSpaceDuplications(this string @string)
        {
            return string.IsNullOrEmpty(@string)
                ? string.Empty
                : Regex.Replace(@string, @"\s{2,1000}", " ");
        }

        public static string RemoveWhiteSpaces(this string @string)
        {
            return string.IsNullOrEmpty(@string)
                ? string.Empty
                : @string.Replace(" ", string.Empty);
        }

        public static DateTime ToDateTime(this string @string, params string[] formats)
        {
            var defaultFormat = new[] {"dd/MM/yy", "dd MMM yy"};
            DateTime.TryParseExact(@string, formats.Any() ? formats : defaultFormat, null,
                DateTimeStyles.None,
                out var date);

            return date;
        }

        public static decimal? ToDecimal(this string @string)
        {
            if (decimal.TryParse(@string, out var value))
                return value;
            return null;
        }

        public static T ToEnum<T>(this string @string) where T : struct
        {
            return (T) Enum.Parse(typeof(T), @string, true);
        }

        public static int? ToInt(this string @string)
        {
            return string.IsNullOrEmpty(@string)
                ? default(int?)
                : int.Parse(@string);
        }

        public static string ToNullIfEmpty(this string @string)
        {
            return @string.IsNullOrEmpty() ? null : @string;
        }
    }
}