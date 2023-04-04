using System;
using MongoDB.Bson;

namespace ESStore.Infrastructure.Data.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToBsonTimestamp(this DateTime date)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var target = DateTime.UtcNow;
            var diff = target.ToUniversalTime() - unixEpoch;
            var seconds = (diff.TotalMilliseconds + 18000000) / 1000;
            var ts = new BsonTimestamp((int)seconds, 1);

            return ts.Timestamp;
        }
    }
}
