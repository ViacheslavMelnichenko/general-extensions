using System;
using System.Text;

namespace General.Extensions
{
    public static class RandomExtensions
    {
        private static Random random => new Random();

        ///<summary>Returns a non-negative random integer</summary>
        public static int GetNumber()
        {
            return random.Next();
        }

        ///<summary>Returns a non-negative random integer that is less than the specified maximum</summary>
        public static int GetNumber(int maxValue)
        {
            return random.Next(maxValue);
        }

        ///<summary>Returns a random integer that is within specified range</summary>
        public static int GetNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        ///<summary>Returns a random floating-point number that is greater than or equal to 0.0 and less than 1.0</summary>
        public static double GetDouble()
        {
            return random.NextDouble();
        }

        ///<summary>Returns a random floating-point number that is less than the specified maximum</summary>
        public static double GetDouble(double maxValue)
        {
            return random.NextDouble() * maxValue;
        }

        ///<summary>Returns a random floating-point number that is within specified range</summary>
        public static double GetDouble(double minValue, double maxValue)
        {
            return random.NextDouble() * maxValue - minValue;
        }

        ///<summary>Returns a random string that is less than 1000 characters length</summary>
        public static string GetString()
        {
            return GetString(0, 1000);
        }

        ///<summary>Returns a random string that is less than the specified maximum</summary>
        public static string GetString(int maxLength)
        {
            return GetString(0, maxLength);
        }

        ///<summary>Returns a random string that is less than the specified maximum</summary>
        public static string GetString(int minLength = 0, int maxLength = int.MaxValue)
        {
            var result = new StringBuilder();
            var array = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789".ToCharArray();
            for (int i = 0; i < GetNumber(minLength, maxLength); i++)
            {
                result.Append(array[GetNumber(array.Length)]);
            }
            return result.ToString();
        }
    }
}
