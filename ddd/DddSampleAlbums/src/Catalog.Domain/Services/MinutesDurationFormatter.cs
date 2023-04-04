using System;

namespace Catalog.Domain.Services
{
    public class MinutesDurationFormatter : IDurationFormatter
    {
        public string Format(double duration)
        {
            return TimeSpan.FromHours(duration).ToString("h\\:mm");
        }
    }
}
