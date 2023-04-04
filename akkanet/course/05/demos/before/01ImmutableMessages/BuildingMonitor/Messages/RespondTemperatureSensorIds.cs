using System.Collections.Generic;

namespace BuildingMonitor.Messages
{
    public sealed class RespondTemperatureSensorIds
    {
        public long RequestId { get; }
        public ISet<string> Ids { get; }

        public RespondTemperatureSensorIds(long requestId, ISet<string> ids)
        {
            RequestId = requestId;
            Ids = ids;
        }
    }
}
