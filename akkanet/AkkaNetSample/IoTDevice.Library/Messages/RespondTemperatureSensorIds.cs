using System.Collections.Immutable;

namespace IoTDevice.Library.Messages
{
    public sealed class RespondTemperatureSensorIds
    {
        public long RequestId { get; }
        public IImmutableSet<string> Ids { get; }

        public RespondTemperatureSensorIds(long requestId, IImmutableSet<string> ids)
        {
            RequestId = requestId;
            Ids = ids;
        }
    }
}
