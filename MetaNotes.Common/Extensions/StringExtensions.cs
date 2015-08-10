using System.Globalization;

namespace MetaNotes.Common
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>Приводит строку к нижнему регистру безопасным способом без вызова эксепшенов</summary>
        public static string ToLowerSafely(this string value, CultureInfo info = null)
        {
            if (value.IsNullOrWhiteSpace())
                return value;

            if (info != null)
                return value.ToLower(info);

            return value.ToLower();
        }
    }
}
