using System.Globalization;

namespace MusicStore.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnake(this string text)
        {
            return string.Concat(text.Select((x, i) =>
                    i > 0 && char.IsUpper(x) ? "_" + x : x.ToString(CultureInfo.InvariantCulture)))
                .ToLowerInvariant();
        }

        public static string ToCamelFirstUpper(this string text)
        {
            var textInfo = new CultureInfo(CultureInfo.CurrentCulture.ToString(), false).TextInfo;
            return textInfo.ToTitleCase(text).Replace("_", string.Empty);
        }
    }
}
