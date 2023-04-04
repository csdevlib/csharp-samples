using System.Globalization;

namespace MusicStore.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DateToString(this DateTime date)
        {
            return date.ToString("s", CultureInfo.CurrentCulture);
        }

        public static DateTime StringToDate(string date)
        {
            return DateTime.ParseExact(date, "s", CultureInfo.CurrentCulture);
        }
    }
}
